using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdOut.Identity.Core.Claims
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        private readonly IPermissionRepository _permissionRepository;
        public CustomUserClaimsPrincipalFactory(
            IPermissionRepository permissionRepository,
            UserManager<User> userManager, 
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> options) 
            : base(userManager, roleManager, options)
        {
            _permissionRepository = permissionRepository;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var claimsPrinciple = await base.CreateAsync(user);
            var claimsIdentity = (ClaimsIdentity)claimsPrinciple.Identity;

            //todo: replace "permission" value to Constant
            var permissions = await _permissionRepository.GetByUserAsync(user.Id);
            var permissionClaims = permissions.Select(p => new Claim("permission", p));

            claimsIdentity.AddClaims(permissionClaims);

            return claimsPrinciple;
        }
    }
}
