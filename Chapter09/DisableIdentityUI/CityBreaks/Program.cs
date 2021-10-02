using CityBreaks.Data;
using CityBreaks.Models;
using CityBreaks.ParameterTransformers;
using CityBreaks.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//.AddCookie(options =>
//{
//    options.LoginPath = "/login";
//});
builder.Services.AddDbContext<CityBreaksContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("CityBreaksContext"));
});

builder.Services.AddDefaultIdentity<CityBreaksUser>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = true;
}).AddEntityFrameworkStores<CityBreaksContext>();


builder.Services.AddRazorPages().AddRazorRuntimeCompilation().AddRazorPagesOptions(options => {
    options.Conventions.Add(new PageRouteTransformerConvention(new KebabPageRouteParameterTransformer()));
});
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    //options.LowercaseQueryStrings = true;
    options.ConstraintMap.Add("slug", typeof(SlugParameterTransformer));
});
builder.Services.AddScoped<ICityService, SimpleCityService>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddTransient<LifetimeDemoService>();
builder.Services.AddSingleton<SingletonService>();
builder.Services.AddTransient<IEmailSender, EmailService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();

app.Run();
