using IdentityServer4.Models;
using System.Collections.Generic;

namespace AdOut.Identity.WebApi
{
    public static class IdentityServerConfig
    {
        //todo: replace strings to Constants
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("permission", new List<string>() { "permission" })
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
                AllowedScopes = { "openid", "profile", "permission"},
                AlwaysIncludeUserClaimsInIdToken = true,
                RedirectUris = { "http://localhost:5001/signin-oidc" }
            },
        };
    }
}
