using System.Threading.Tasks;
using AdOut.Identity.Model.Database;

namespace AdOut.Identity.Model.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<User> FindByIdAsync(string userId);
        Task<User> FindByNameAsync(string userName);
        Task AddRoleAsync(string userId, Enums.Role role);
        Task RemoveRoleAsync(string userId, Enums.Role role);
    }
}
