using System.Threading.Tasks;
using AdOut.Identity.Model.Enums;
using AdOut.Identity.Model.Interfaces.Managers;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdOut.Identity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Customer")]
        [Route("add-role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddRole(string toUserId, Role role)
        {
            var fromUserId = User.Identity.GetSubjectId();
            await _userManager.AddRoleAsync(fromUserId, toUserId, role);
            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Customer")]
        [Route("remove-role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveRole(string toUserId, Role role)
        {
            var fromUserId = User.Identity.GetSubjectId();
            await _userManager.RemoveRoleAsync(fromUserId, toUserId, role);
            return NoContent(); 
        }
    }
}