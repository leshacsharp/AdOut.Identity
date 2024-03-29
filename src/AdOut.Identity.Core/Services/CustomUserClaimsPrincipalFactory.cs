﻿using AdOut.Identity.Model;
using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdOut.Identity.Core.Services
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
            {
                throw new ArgumentNullException(nameof(user));
            }

            var claimsPrinciple = await base.CreateAsync(user);
            var claimsIdentity = (ClaimsIdentity)claimsPrinciple.Identity;

            var permissions = await _permissionRepository.GetByUserAsync(user.Id);
            var permissionClaims = permissions.Select(p => new Claim(Constants.ClaimsTypes.Permission, p));
            claimsIdentity.AddClaims(permissionClaims);

            return claimsPrinciple;
        }
    }
}
