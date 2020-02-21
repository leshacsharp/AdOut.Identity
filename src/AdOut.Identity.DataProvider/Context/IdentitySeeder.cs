using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdOut.Identity.DataProvider.Context
{
    public class IdentitySeeder : IDatabaseSeeder
    {
        public void Seed(ModelBuilder builder)
        {
            var testPermission = new Permission()
            {
                Id = 1,
                Name = "test permission"
            };
            builder.Entity<Permission>().HasData(testPermission);

            var adminRole = new Role()
            {
                Id = "b1419175-af91-4dff-ba78-13201d7538f4",
                Name = "admin",
                NormalizedName = "admin".ToUpper()
            };
            builder.Entity<Role>().HasData(adminRole);

            var adminRolePermissions = new RolePermission()
            {
                RoleId = adminRole.Id,
                PermissionId = testPermission.Id
            };
            builder.Entity<RolePermission>().HasData(adminRolePermissions);

            var hasher = new PasswordHasher<User>();
            var adminUser = new User()
            {
                Id = "889c437a-feab-4a1e-b6d4-d52596fdbdf9",
                UserName = "alex",
                NormalizedUserName = "alex".ToUpper(),
                DateRegistration = DateTime.UtcNow,
                Email = "admin@email.com",
                NormalizedEmail = "admin@email.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin123"),
                SecurityStamp = string.Empty
            };
            builder.Entity<User>().HasData(adminUser);

            var adminUserRole = new IdentityUserRole<string>()
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        }
    }
}
