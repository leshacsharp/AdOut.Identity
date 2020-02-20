using AdOut.Identity.Model.Database;
using AdOut.Identity.Model.Interfaces.Managers;
using AdOut.Identity.Model.Model.Managers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using System;
using AdOut.Identity.Model.Api;

namespace AdOut.Identity.Core.Managers
{
    public class AuthManager : IAuthManager
    {  
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public AuthManager(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
                //todo: make constant
                authResult.Errors.Add($"User with name {registrationModel.UserName} has already registrated");
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

            //todo: replace registrationModel.Role to Enum
            var roleExists = await _roleManager.RoleExistsAsync(registrationModel.Role);
            if(!roleExists)
            {
                throw new ArgumentException($"Role={registrationModel.Role} does not exists");
            }

            var addingRoleResult = await _userManager.AddToRoleAsync(newUser, registrationModel.Role);
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
                //todo: make constants
                authResult.Errors.Add("userName or password is invalid");
            }

            return authResult;
        }

        public Task LogOutAsync()
        {
            return _signInManager.SignOutAsync();
        }
    }
}
