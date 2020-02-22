using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using static AdOut.Identity.Model.Constants;

namespace AdOut.Identity.WebApi
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(ClaimsTypes.Permission, new List<string>() { ClaimsTypes.Permission })
            };

        public static IEnumerable<ApiResource> Apis =>
        new List<ApiResource>
        {
            
        };

        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "mvc",
                AllowedGrantTypes = GrantTypes.Code,
                RequireConsent = false,
                RequirePkce = true,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = 
                {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     ClaimsTypes.Permission
                },
                AlwaysIncludeUserClaimsInIdToken = true,
                RedirectUris = { "http://localhost:5001/signin-oidc" }
            },
        };
    }
}
