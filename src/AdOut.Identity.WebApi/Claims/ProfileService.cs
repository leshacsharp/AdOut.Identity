using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Exceptions;
using AdOut.Identity.Model.Interfaces.Managers;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdOut.Identity.WebApi.Claims
{
    //todo: move to the Core module
    public class ProfileService : IProfileService
    {
        private readonly IUserManager _userManager;
        private readonly IUserClaimsPrincipalFactory<User> _userClaimsFactory;

        public ProfileService(IUserManager userManager, IUserClaimsPrincipalFactory<User> userClaimsFactory)
        {
            _userManager = userManager;
            _userClaimsFactory = userClaimsFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null)
            {
                throw new ObjectNotFoundException($"User with id={userId} not found. \nCaller was {context.Caller} and Client was {context.Client.ClientName}");
            }

            var claimsPrinciple = await _userClaimsFactory.CreateAsync(user);
            var userClaims = claimsPrinciple.Claims;

            var issuedClaims = userClaims.Where(c => context.RequestedClaimTypes.Contains(c.Type)).ToList();
            context.IssuedClaims = issuedClaims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(userId);
            context.IsActive = user != null;
        }
    }
}
