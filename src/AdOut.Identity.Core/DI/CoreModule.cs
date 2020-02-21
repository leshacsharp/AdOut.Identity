using AdOut.Identity.Core.Claims;
using AdOut.Identity.Core.Managers;
using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AdOut.Identity.Core.DI
{
    public static class CoreModule
    {
        public static void AddCoreModule(this IServiceCollection services)
        {
            services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomUserClaimsPrincipalFactory>();

            services.AddScoped<IAuthManager, AuthManager>();
        }
    }
}
