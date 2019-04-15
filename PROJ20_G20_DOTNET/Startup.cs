using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJ20_G20_DOTNET.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PROJ20_G20_DOTNET.Models.Domain;
using PROJ20_G20_DOTNET.Data.Repositories;

namespace PROJ20_G20_DOTNET
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
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region DBContext config
            services.AddDbContext<JiuJitsuDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Identity config
            services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<JiuJitsuDbContext>();
            #endregion

            #region Authentication config

            #endregion

            #region DBInitializer & Repository injection
            services.AddScoped<IActiviteitRepository, ActiviteitRepository>();
            services.AddScoped<ILidRepository, LidRepository>();
            services.AddScoped<IAanwezigheidRepository, AanwezigheidRepository>();
            services.AddScoped<IInschrijvingRepository, InschrijvingRepository>();
            services.AddScoped<DbInitializer>();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInitializer dbInitializer)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else {
                app.UseExceptionHandler("/Shared/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller=Lid}/{action=Index}/{id?}");
            });

            dbInitializer.InitializeData();
        }
    }
}
