using AdOut.Extensions.Filters;
using AdOut.Identity.Core.Services;
using AdOut.Identity.DataProvider.Context;
using AdOut.Identity.Model.Database;
using AdOut.Identity.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AdOut.Identity.WebApi
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
            //services.AddMvc(options => 
            //{
            //    options.EnableEndpointRouting = false;
            //    options.Filters.Add(typeof(ExceptionFilterAttribute));
            //});
            //services.AddControllers();

            services.AddControllersWithViews(options => 
            {
                options.Filters.Add<ExceptionFilterAttribute>();
            });

            //todo: make Different connections for dev and prod configurations
            services.AddDbContext<IdentityContext>(options => 
                     options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddIdentity<User, Role>(setup =>
            {
                setup.Password.RequireUppercase = false;
                setup.Password.RequireDigit = false;
                setup.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<IdentityContext>();

            services.AddDataProviderServices();
            services.AddCoreServices();

            var identityServerBuilder = services.AddIdentityServer(options => options.UserInteraction.LoginUrl = "/auth/login")
                .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                .AddInMemoryApiResources(IdentityServerConfig.Apis)
                .AddInMemoryClients(IdentityServerConfig.Clients)
                .AddAspNetIdentity<User>()
                .AddProfileService<ProfileService>();

            identityServerBuilder.AddDeveloperSigningCredential();

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo { Title = "AdOut.Identity API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(b =>
                {
                    b.WithOrigins("http://localhost:3000");
                    b.AllowAnyMethod();
                    b.AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

           // app.UseHttpsRedirection();
            app.UseRouting();

            //app.UseIdentityServer();
            //app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "AdOut.Identity API V1");
            });

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
