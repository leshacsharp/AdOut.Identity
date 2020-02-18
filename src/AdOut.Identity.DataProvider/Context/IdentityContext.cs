using AdOut.Identity.Model.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdOut.Identity.DataProvider.Context
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Permission> Permissions { get; set; }
    }
}
