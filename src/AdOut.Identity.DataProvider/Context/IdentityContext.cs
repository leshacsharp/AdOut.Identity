using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdOut.Identity.DataProvider.Context
{
    public class IdentityContext : IdentityDbContext<User, Role, string>, IDatabaseContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> dbContextOptions)
            : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RolePermission>()
                   .HasKey(table => new { table.RoleId, table.PermissionId });
        }
    }
}
