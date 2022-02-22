using CityBreaks.AuthorizationHandlers;
using CityBreaks.AuthorizationRequirements;
using CityBreaks.CustomRouteContraints;
using CityBreaks.Data;
using CityBreaks.Logging;
using CityBreaks.Models;
using CityBreaks.PageRouteModelConventions;
using CityBreaks.ParameterTransformers;
using CityBreaks.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using static CityBreaks.Pages.CityModel;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}")
    .WriteTo.File(path: "Logs\\log.json", formatter: new JsonFormatter(), rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("Starting up");
try
{
    
    var builder = WebApplication.CreateBuilder();
    //var builder = WebApplication.CreateBuilder(new WebApplicationOptions
    //{
    //    EnvironmentName = "Staging"
    //});
    builder.Host.UseSerilog();

    // Add builder.Services to the container.
    builder.Services.AddRazorPages(options =>
    {
        //options.Conventions.AddPageRoute("/Index", "FindMe");
        options.Conventions.AuthorizeFolder("/CityManager");
        options.Conventions.AuthorizeFolder("/CountryManager");
        options.Conventions.AuthorizeFolder("/PropertyManager");
        options.Conventions.AuthorizeFolder("/RolesManager", "ViewRolesPolicy");
        options.Conventions.AuthorizeFolder("/ClaimsManager");
        options.Conventions.Add(new CultureTemplatePageRouteModelConvention());
        options.Conventions.Add(new PageRouteTransformerConvention(new KebabPageRouteParameterTransformer()));
    });
    builder.Services.Configure<RouteOptions>(options =>
    {
        options.LowercaseUrls = true;
        options.ConstraintMap.Add("city", typeof(CityRouteConstraint));
        options.ConstraintMap.Add("slug", typeof(SlugParameterTransformer));
    });

    builder.Services.AddDbContext<CityBreaksContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("CityBreaksContext"));
    });
    builder.Services.AddDefaultIdentity<CityBreaksUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<CityBreaksContext>();
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.AccessDeniedPath = "/identity/account/access-denied";
    });
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("ViewRolesPolicy", policyBuilder =>
            policyBuilder.AddRequirements(new ViewRolesRequirement(months: -6)));
        options.AddPolicy("ViewClaimsPolicy", policyBuilder =>
            policyBuilder.AddRequirements(new ViewClaimsRequirement()));
    });

    builder.Services.AddScoped<ICityService, CityService>();
    builder.Services.AddTransient<LifetimeDemoService>();
    builder.Services.AddSingleton<SingletonService>();
    builder.Services.AddScoped<IPriceService, FrPriceService>();
    builder.Services.AddScoped<IPriceService, GbPriceService>();
    builder.Services.AddScoped<IPriceService, UsPriceService>();
    builder.Services.AddScoped<IPriceService, DefaultPriceService>();
    builder.Services.AddScoped<IPropertyService, PropertyService>();
    //builder.Host.UseEnvironment("Production");
    //if (builder.Environment.IsDevelopment()) 
    //{ 
    //    builder.Services.AddTransient<IEmailSender, EmailService>();
    //}
    //else
    //{
        builder.Services.AddTransient<IEmailSender, ProductionEmailService>();
    //}

    //builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection(nameof(SmtpSettings)));

    builder.Services.AddSingleton<IAuthorizationHandler, IsInRoleHandler>();
    builder.Services.AddSingleton<IAuthorizationHandler, HasClaimHandler>();
    builder.Services.AddSingleton<IAuthorizationHandler, ViewRolesHandler>();
    builder.Services.AddSingleton<IAuthorizationHandler, PropertyAuthorizationHandler>();
    builder.Services.AddSingleton<IBookingService, BookingService>();
    builder.Services.AddTransient<ILoggerProvider, EmailLoggerProvider>();

    var app = builder.Build();
    
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        //app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStatusCodePagesWithReExecute("/errors/{0}");
    app.UseStaticFiles();
    
    //app.UseSerilogRequestLogging();
    
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapRazorPages();


    app.MapPost("/api/property/booking",
        (BookingInputModel model, IBookingService bookingService) =>
    {
        var booking = new Booking
        {
            StartDate = model.StartDate.Value,
            EndDate = model.EndDate.Value,
            NumberOfGuests = model.NumberOfGuests,
            DayRate = model.Property.DayRate
        };
        var totalCost = bookingService.Calculate(booking);
        return Results.Ok(new { TotalCost = totalCost });
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start failed");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}