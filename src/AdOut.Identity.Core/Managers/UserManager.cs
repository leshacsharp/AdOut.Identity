using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Exceptions;
using AdOut.Identity.Model.Interfaces.Managers;
using Microsoft.AspNetCore.Identity;
using AdOut.Identity.Common.Helpers;
using System.Threading.Tasks;
using System.Linq;
using static AdOut.Identity.Model.Constants;

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

        public async Task AddRoleAsync(string fromUserId, string toUserId, Model.Enums.Role addedRole)
        {
            var userHavePermission = await HavePermissionForOperationsOverRole(fromUserId, addedRole);
            if (!userHavePermission)
            {
                var exceptionMessage = string.Format(Messages.DONT_HAVE_PERMISSIONS_FOR_ADDING_ROLES_T, fromUserId, addedRole);
                throw new ForbiddenException(exceptionMessage);
            }

            var toUser = await _identityUserManager.FindByIdAsync(toUserId);
            if (toUser == null)
                throw new ObjectNotFoundException($"User with id={toUserId} not found");

            var addedRoleName = addedRole.ToString();
            await _identityUserManager.AddToRoleAsync(toUser, addedRoleName);
        }

        public async Task RemoveRoleAsync(string fromUserId, string toUserId, Model.Enums.Role removedRole)
        {
            var userHavePermission = await HavePermissionForOperationsOverRole(fromUserId, removedRole);
            if (!userHavePermission)
            {
                var exceptionMessage = string.Format(Messages.DONT_HAVE_PERMISSIONS_FOR_DELETING_ROLES_T, fromUserId, removedRole);
                throw new ForbiddenException(exceptionMessage);
            }

            var toUser = await _identityUserManager.FindByIdAsync(toUserId);
            if (toUser == null)
                throw new ObjectNotFoundException($"User with id={toUserId} not found");

            var removedRoleName = removedRole.ToString();
            await _identityUserManager.RemoveFromRoleAsync(toUser, removedRoleName);
        }

        private async Task<bool> HavePermissionForOperationsOverRole(string userId, Model.Enums.Role role)
        {
            var user = await _identityUserManager.FindByIdAsync(userId);
            if (user == null)
                throw new ObjectNotFoundException($"User with id={userId} not found");

            var userRolesNames = await _identityUserManager.GetRolesAsync(user);
            var userRoles = userRolesNames.ToEnum<Model.Enums.Role>();

            var permissions = Permissions.PERMISSIONS_FOR_OPERATIONS_OVER_ROLE;
            var userHavePermission = userRoles.Any(sr => permissions[sr].Contains(role));
            return userHavePermission;
        }
    }
}
