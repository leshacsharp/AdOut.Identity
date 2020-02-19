using AdOut.Identity.Model.Api;
using AdOut.Identity.Model.Model.Managers;
using System.Threading.Tasks;

namespace AdOut.Identity.Model.Interfaces.Managers
{
    public interface IAuthManager
    {
        Task<AuthResult> RegisterAsync(RegistrationModel registrationModel);
        Task<AuthResult> LogInAsync(LogInModel logInModel);
        Task LogOutAsync();
    }
}
