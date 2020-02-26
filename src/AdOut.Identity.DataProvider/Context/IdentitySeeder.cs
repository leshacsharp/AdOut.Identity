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

            var adminRoleName = Model.Enums.Role.Admin.ToString();
            var adminRole = new Role()
            {
                Id = "daddy175-af91-4dff-ba78-13201d7538f4",
                Name = adminRoleName,
                NormalizedName = adminRoleName.ToUpper()
            };
            builder.Entity<Role>().HasData(adminRole);

            var customerRoleName = Model.Enums.Role.Customer.ToString();
            var customerRole = new Role()
            {
                Id = "704f16ad-a641-4fb3-b6bd-92a6aa6473f8",
                Name = customerRoleName,
                NormalizedName = customerRoleName.ToUpper()
            };
            builder.Entity<Role>().HasData(customerRole);

            var moderatorRoleName = Model.Enums.Role.Moderator.ToString();
            var moderatorRole = new Role()
            {
                Id = "81e332df-e64b-4c5d-8404-4c6655383f82",
                Name = moderatorRoleName,
                NormalizedName = moderatorRoleName.ToUpper()
            };
            builder.Entity<Role>().HasData(moderatorRole);

            var userRoleName = Model.Enums.Role.User.ToString();
            var userRole = new Role()
            {
                Id = "b1419175-af91-4dff-ba78-13201d7538f4",
                Name = userRoleName,
                NormalizedName = userRoleName.ToUpper()
            };
            builder.Entity<Role>().HasData(userRole);

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

            var testUser = new User()
            {
                Id = "7d60c3d4-7b3d-4d04-8963-301d64d65452",
                UserName = "test",
                NormalizedUserName = "test".ToUpper(),
                DateRegistration = DateTime.UtcNow,
                Email = "test@email.com",
                NormalizedEmail = "test@email.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test123"),
                SecurityStamp = string.Empty
            };
            builder.Entity<User>().HasData(testUser);

            var adminUserRole = new IdentityUserRole<string>()
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);

            var testUserRole = new IdentityUserRole<string>()
            {
                UserId = testUser.Id,
                RoleId = userRole.Id
            };
            builder.Entity<IdentityUserRole<string>>().HasData(testUserRole);
        }
    }
}
