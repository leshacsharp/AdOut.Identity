using IdentityServer4.Models;
using System.Collections.Generic;

namespace AdOut.Identity.WebApi
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> Apis =>
        new List<ApiResource>
        {

        };

        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            
        };
    }
}
