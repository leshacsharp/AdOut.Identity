using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdOut.Identity.DataProvider.Context
{
    public class IdentityContext : IdentityDbContext<User, Role, string>, IDatabaseContext
    {
        private readonly IDatabaseSeeder _databaseSeeder;
        public IdentityContext(DbContextOptions<IdentityContext> dbContextOptions, IDatabaseSeeder databaseSeeder)
            : base(dbContextOptions)
        {
            _databaseSeeder = databaseSeeder;
            Database.EnsureCreated();
        }
 
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _databaseSeeder.Seed(builder);

            builder.Entity<RolePermission>()
                   .HasKey(table => new { table.RoleId, table.PermissionId });

            base.OnModelCreating(builder);
        }
    }
}
