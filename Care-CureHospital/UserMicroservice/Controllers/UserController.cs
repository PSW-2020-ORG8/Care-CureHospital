using System.Text;
using Backend.Model.AllActors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UserMicroservice.Dto;
using UserMicroservice.Service;

namespace UserMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private readonly AppSettings appSettings;

        public UserController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            this.userService = userService;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateDto model)
        {
            var user = userService.Authenticate(model.Username, model.Password, Encoding.ASCII.GetBytes(appSettings.Secret));
            if (user == null)
            {
                return Forbid();
            }
            return Ok(user);
        }

        [Authorize(Roles = Role.Admin + "," + Role.Patient)]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new { Token = "", Message = "Logged Out" });
        }
    }
}
