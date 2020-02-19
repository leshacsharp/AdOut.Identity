using AdOut.Identity.Core.Managers;
using AdOut.Identity.Model.Interfaces.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace AdOut.Identity.Core.DI
{
    public static class CoreModule
    {
        public static void AddCoreModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthManager, AuthManager>();
        }
    }
}
