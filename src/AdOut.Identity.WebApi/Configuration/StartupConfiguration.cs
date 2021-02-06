using AdOut.Identity.Core.Managers;
using AdOut.Identity.Core.Services;
using AdOut.Identity.DataProvider.Context;
using AdOut.Identity.DataProvider.Repositories;
using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Context;
using AdOut.Identity.Model.Interfaces.Managers;
using AdOut.Identity.Model.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AdOut.Identity.WebApi.Configuration
{
    public static class StartupConfiguration
    {
        public static void AddDataProviderServices(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseContext, IdentityContext>();
            services.AddScoped<IDatabaseSeeder, IdentitySeeder>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
        }

        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomUserClaimsPrincipalFactory>();

            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IAuthManager, AuthManager>();
        }
    }
}
