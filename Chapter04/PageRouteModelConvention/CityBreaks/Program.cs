using CityBreaks.CustomRouteContraints;
using CityBreaks.PageRouteModelConventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => {
    options.Conventions.AddPageRoute("/Index", "FindMe");
    options.Conventions.Add(new CultureTemplatePageRouteModelConvention());
});
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("city", typeof(CityRouteConstraint));
});




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

app.MapRazorPages();

app.Run();
