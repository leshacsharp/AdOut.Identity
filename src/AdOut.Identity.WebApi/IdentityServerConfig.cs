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
                new IdentityResource(IdentityResourcesNames.Postition, new List<string>() 
                {
                    ClaimsTypes.Role,
                    ClaimsTypes.Permission
                })
            };

        public static IEnumerable<ApiResource> Apis =>
        new List<ApiResource>
        {
            new ApiResource(ApisNames.Planning),
            new ApiResource(ApisNames.Point)
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
                     IdentityResourcesNames.Postition,
                     ApisNames.Planning,
                     ApisNames.Point,
                },
                AlwaysIncludeUserClaimsInIdToken = true,
                RedirectUris = { "http://localhost:5001/signin-oidc" }
            },
        };
    }
}
