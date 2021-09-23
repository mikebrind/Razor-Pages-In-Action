using CityBreaks.Data;
using CityBreaks.PageRouteModelConventions;
using CityBreaks.ParameterTransformers;
using CityBreaks.RouteContstraints;
using CityBreaks.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CityBreaks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
            });
            services.AddDbContext<CityBreaksContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("CityBreaksContext"));
            });
            services.AddRazorPages().AddRazorRuntimeCompilation().AddRazorPagesOptions(options => {
                options.Conventions.Add(new PageRouteTransformerConvention(new KebabPageRouteParameterTransformer()));
            });
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.ConstraintMap.Add("slug", typeof(SlugParameterTransformer));
            });
            services.AddScoped<ICityService, SimpleCityService>();
            services.AddScoped<ICityService, CityService>();
            
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddTransient<LifetimeDemoService>();
            services.AddSingleton<SingletonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
