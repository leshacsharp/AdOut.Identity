using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Context;
using AdOut.Identity.Model.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AdOut.Identity.DataProvider.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDatabaseContext context)
            : base(context)
        {

        }

        public Task<List<string>> GetByUserAsync(string userId)
        {
            var permissions = from ur in Context.UserRoles
                              join r in Context.Roles on ur.RoleId equals r.Id
                              join rp in Context.RolePermissions on r.Id equals rp.RoleId
                              join p in Context.Permissions on rp.PermissionId equals p.Id
                              where ur.UserId == userId
                              select p.Name;

            return permissions.Distinct().ToListAsync();
        }

        public Task<List<string>> GetByRoleAsync(string roleId)
        {
            var permissions = from rp in Context.RolePermissions
                              join p in Context.Permissions on rp.PermissionId equals p.Id
                              where rp.RoleId == roleId
                              select p.Name;
                             
            return permissions.Distinct().ToListAsync();
        }
    }
}
