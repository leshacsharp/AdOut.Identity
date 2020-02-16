using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace AdOut.Identity.WebApi
{
    public static class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser{SubjectId = "818727", Username = "alex", Password = "alex",

                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Aleksey Alekseevich"),
                    new Claim(JwtClaimTypes.GivenName, "Aleksey"),
                    new Claim(JwtClaimTypes.FamilyName, "Alekseevich"),
                    new Claim(JwtClaimTypes.Email, "alex@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Kiev', 'postal_code': 69118, 'country': 'Ukraine' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser{SubjectId = "88421113", Username = "oly", Password = "oly",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Oly Oliavna"),
                    new Claim(JwtClaimTypes.GivenName, "Oly"),
                    new Claim(JwtClaimTypes.FamilyName, "Oliavna"),
                    new Claim(JwtClaimTypes.Email, "oly@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://oly.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Kiev', 'postal_code': 69118, 'country': 'Ukraine' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "somewhere")
                }
            }
        };
    }
}
