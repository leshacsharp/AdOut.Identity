using AdOut.Identity.Model.Api;
using AdOut.Identity.Model.Classes;
using AdOut.Identity.Model.Interfaces.Managers;
using AdOut.Identity.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdOut.Identity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ModelStateFilter]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        public AccountController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegistrationModel registrationModel)
        {
            var registrationResult = await _authManager.RegisterAsync(registrationModel);
            if (!registrationResult.IsSuccessed)
            {
                var errors = string.Join("\n", registrationResult.Errors);
                return BadRequest(errors);
            }

            return Ok(registrationResult);
        }
    }
}