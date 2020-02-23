using AdOut.Identity.Model.Enums;
using System.Collections.Generic;

namespace AdOut.Identity.Model
{
    public class Constants
    {
        //_T - template
        public static class Messages
        {
            public const string USER_EXISTS_T = "User with name {0} has already registrated";
            public const string USER_INVALID = "UserName or password is invalid";
            public const string DONT_HAVE_PERMISSIONS_FOR_ADDING_ROLES_T = "User with id={0} doesn't have permissions for adding {1} role";
            public const string DONT_HAVE_PERMISSIONS_FOR_DELETING_ROLES_T = "User with id={0} don't have permissions for deleting {1} role";
        }

        public static class IdentityResourcesNames
        {
            public const string Postition = "position";
        }

        public static class ClaimsTypes
        {
            public const string Role = "role";
            public const string Permission = "permission";
        }

        public static class Permissions
        {
            public static Dictionary<Role, List<Role>> PERMISSIONS_FOR_OPERATIONS_OVER_ROLE= new Dictionary<Role, List<Role>>()
            {
                { Role.Admin, new List<Role>() { Role.Admin, Role.Customer, Role.Moderator, Role.User } },
                { Role.Customer, new List<Role>() { Role.Moderator } },
                { Role.Moderator, new List<Role>() },
                { Role.User, new List<Role>() }
            };
        }

        public static class HttpStatusCodes
        {
            public const int Status400BadRequest = 400;
            public const int Status401Unauthorized = 401;
            public const int Status403Forbidden = 403;
        }
    }
}
