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
using System.Security.Claims;

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
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            options.UseSqlServer(Configuration.GetConnectionString("TyboDesktopConnection")));
            #endregion

            #region Identity config
            services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<JiuJitsuDbContext>();
            #endregion

            #region Auth config
            services.AddAuthorization(options => {
                //Function policies
                options.AddPolicy("Lid", policy => policy.RequireClaim(ClaimTypes.Role, "lid"));
                options.AddPolicy("Beheerder", policy => policy.RequireClaim(ClaimTypes.Role, "beheerder"));
                options.AddPolicy("Trainer", policy => policy.RequireClaim(ClaimTypes.Role, "trainer"));
                options.AddPolicy("Proeflid", policy => policy.RequireClaim(ClaimTypes.Role, "proeflid"));
                options.AddPolicy("Gast", policy => policy.RequireClaim(ClaimTypes.Role, "gast"));

                //Action policies
                options.AddPolicy("ViewHome", policy => policy.RequireClaim(ClaimTypes.Role, "viewHome"));
                options.AddPolicy("ViewAttendings", policy => policy.RequireClaim(ClaimTypes.Role, "viewAttendings"));
                options.AddPolicy("ViewPersonalDetails", policy => policy.RequireClaim(ClaimTypes.Role, "viewPersonalDetails"));
            });
            #endregion

            #region DBInitializer & Repository injection
            services.AddScoped<IActiviteitRepository, ActiviteitRepository>();
            services.AddScoped<ILidRepository, LidRepository>();
            services.AddScoped<IAanwezigheidRepository, AanwezigheidRepository>();
            services.AddScoped<IInschrijvingRepository, InschrijvingRepository>();
            services.AddScoped<IActiviteitInschrijvingRepository, ActiviteitInschrijvingRepository>();
            services.AddScoped<IGraadRepository, GraadRepository>();
            services.AddScoped<IOefeningRepository, OefeningRepository>();
            services.AddScoped<IRaadplegingRepository, RaadplegingRepository>();

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
                    template: "{controller=Home}/{action=Index}/{id?}/{id2?}");
            });

            dbInitializer.InitializeData().Wait();
        }
    }
}
