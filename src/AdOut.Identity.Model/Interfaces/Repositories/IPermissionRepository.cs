using AdOut.Extensions.Repositories;
using AdOut.Identity.Model.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdOut.Identity.Model.Interfaces.Repositories
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        Task<List<string>> GetByUserAsync(string userId);
        Task<List<string>> GetByRoleAsync(string roleId);
    }
}
