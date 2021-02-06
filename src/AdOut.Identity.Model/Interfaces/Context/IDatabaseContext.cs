using AdOut.Identity.Model.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdOut.Identity.Model.Interfaces.Context
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<RolePermission> RolePermissions { get; set; }

        DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        DbSet<IdentityUserLogin<string>> UserLogins { get; set; }
        DbSet<IdentityUserToken<string>> UserTokens { get; set; }
        DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        DbSet<IdentityRoleClaim<string>> RoleClaims { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
