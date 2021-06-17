using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenges.API.Response;
using Challenges.Application.Services;

namespace Challenges.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetUserDetails()
        {
            var userDetails = await _userService.GetUserDetails();
            return Ok(userDetails);
        }
    }
}
