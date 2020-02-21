using AdOut.Identity.DataProvider.Context;
using AdOut.Identity.DataProvider.Repositories;
using AdOut.Identity.Model.Interfaces.Context;
using AdOut.Identity.Model.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AdOut.Identity.DataProvider.DI
{
    public static class DataProviderModule
    {
        public static void AddDataProviderModule(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseContext, IdentityContext>();
            services.AddScoped<IDatabaseSeeder, IdentitySeeder>();

            services.AddScoped<IPermissionRepository, PermissionRepository>();
        }
    }
}
