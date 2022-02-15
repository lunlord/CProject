using CProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace CProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connection))
                .AddIdentity<User, IdentityRole>(options =>
                {               
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz1234567890";
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 8;
                })
                .AddEntityFrameworkStores<UserContext>();

            services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Home/AccessDenied";
        });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Director", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "Director");
                });

                options.AddPolicy("Storekeeper", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "Storekeeper");
                });
                options.AddPolicy("Logistician", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "Logistician");
                });
                options.AddPolicy("Wholesaler", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "Wholesaler");
                });
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}