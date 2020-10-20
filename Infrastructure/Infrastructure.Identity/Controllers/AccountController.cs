using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utility.Tools.Commands;

namespace Infrastructure.Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]AuthenticateUser command) =>
            Json(await _userService.LoginAsync(command.Email,command.Password));
    }
}
