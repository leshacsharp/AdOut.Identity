using System.Threading.Tasks;
using AdOut.Identity.Model.Enums;
using AdOut.Identity.Model.Interfaces.Managers;
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
        [Route("add-role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddRole(string fromUserId, string toUserId, Role role)
        {
            await _userManager.AddRoleAsync(fromUserId, toUserId, role);
            return NoContent();
        }

        [HttpDelete]
        [Route("remove-role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RemoveRole(string fromUserId, string toUserId, Role role)
        {
            await _userManager.RemoveRoleAsync(fromUserId, toUserId, role);
            return NoContent(); 
        }
    }
}