using System.Threading.Tasks;
using AdOut.Identity.Model.Database;

namespace AdOut.Identity.Model.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<User> FindByIdAsync(string userId);
        Task<User> FindByNameAsync(string userName);
        Task AddRoleAsync(string fromUserId, string touUserId, Enums.Role addedRole);
        Task RemoveRoleAsync(string fromUserId, string touUserId, Enums.Role removedRole);
    }
}
