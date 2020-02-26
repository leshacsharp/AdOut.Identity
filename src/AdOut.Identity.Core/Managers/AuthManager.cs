using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Managers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using System;
using AdOut.Identity.Model.Api;
using static AdOut.Identity.Model.Constants;
using AdOut.Identity.Model.Classes;

namespace AdOut.Identity.Core.Managers
{
    public class AuthManager : IAuthManager
    {  
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthManager(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthResult> RegisterAsync(RegistrationModel registrationModel)
        {
            if (registrationModel == null)
                throw new ArgumentNullException(nameof(registrationModel));
            
            var authResult = new AuthResult();

            var user = await _userManager.FindByNameAsync(registrationModel.UserName);
            if (user != null)
            {
                var errorMessage = string.Format(Messages.USER_EXISTS_T, registrationModel.UserName);
                authResult.Errors.Add(errorMessage);
                return authResult;
            }

            var newUser = new User()
            {
                UserName = registrationModel.UserName,
                Email = registrationModel.Email
            };
    
            var creatingUserResult = await _userManager.CreateAsync(newUser, registrationModel.Password);
            if(!creatingUserResult.Succeeded)
            {
                var errorMessages = creatingUserResult.Errors.Select(error => error.Description);
                authResult.Errors.AddRange(errorMessages);
                return authResult;
            }

            var roleName = registrationModel.Role.ToString();
            var addingRoleResult = await _userManager.AddToRoleAsync(newUser, roleName);
            if(!addingRoleResult.Succeeded)
            {
                var errorMessages = addingRoleResult.Errors.Select(error => error.Description);
                authResult.Errors.AddRange(errorMessages);
                return authResult;
            }

            return authResult;
        }

        public async Task<AuthResult> LogInAsync(LogInModel logInModel)
        {
            if (logInModel == null)
                throw new ArgumentNullException(nameof(logInModel));

            var authResult = new AuthResult();

            var signInResult = await _signInManager.PasswordSignInAsync(logInModel.UserName, logInModel.Password, logInModel.Remember, true);
            if(!signInResult.Succeeded)
            {
                authResult.Errors.Add(Messages.USER_INVALID);
            }

            return authResult;
        }

        public Task LogOutAsync()
        {
            return _signInManager.SignOutAsync();
        }
    }
}
