using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Exceptions;
using AdOut.Identity.Model.Interfaces.Managers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AdOut.Identity.Core.Managers
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<User> _identityUserManager;
        public UserManager(UserManager<User> identityUserManager)
        {
            _identityUserManager = identityUserManager;
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return _identityUserManager.FindByIdAsync(userId);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return _identityUserManager.FindByNameAsync(userName);
        }

        public async Task AddRoleAsync(string userId, Model.Enums.Role role)
        {
            var user = await _identityUserManager.FindByIdAsync(userId);
            if (user == null)
                throw new ObjectNotFoundException($"User with id={userId} not found");

            var roleName = Enum.GetName(typeof(Model.Enums.Role), role);
            await _identityUserManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveRoleAsync(string userId, Model.Enums.Role role)
        {
            var user = await _identityUserManager.FindByIdAsync(userId);
            if (user == null)
                throw new ObjectNotFoundException($"User with id={userId} not found");
            
            var roleName = Enum.GetName(typeof(Model.Enums.Role), role);
            await _identityUserManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}
