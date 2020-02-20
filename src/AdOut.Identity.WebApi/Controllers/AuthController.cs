using AdOut.Identity.Model.Api;
using AdOut.Identity.Model.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdOut.Identity.WebApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthManager _authManager;
        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        //IdentitySystem IdentityProcess IdentityLogic

        [HttpGet]
        public IActionResult LogIn(string returnUrl)
        {
            var logInModel = new LogInModel() { ReturnUrl = returnUrl };
            return View(logInModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
        {
            if(!ModelState.IsValid)
            {
                return View(logInModel);
            }

            var logInResult = await _authManager.LogInAsync(logInModel);
            if(!logInResult.IsSuccessed)
            {
                var errors = string.Join("\n", logInResult.Errors);
                ModelState.AddModelError("", errors);
                return View(logInModel);
            }

            return Redirect(logInModel.ReturnUrl);
        }

        [HttpPost]
        public Task LogOut()
        {
            return _authManager.LogOutAsync();
        }
    }
}