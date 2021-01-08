using System.Text;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UserMicroservice.Dto;
using UserMicroservice.Service;

namespace UserMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AppSettings appSettings;
        private readonly IDomainEventService eventService;

        public UserController(IUserService userService, IOptions<AppSettings> appSettings, IDomainEventService eventService)
        {
            this.userService = userService;
            this.appSettings = appSettings.Value;
            this.eventService = eventService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateDto model)
        {
            var user = userService.Authenticate(model.Username, model.Password, Encoding.ASCII.GetBytes(appSettings.Secret));
            if (user == null)
            {
                return Forbid();
            }
            eventService.Save(new LoginEvent(user.Username,user.Id));
            return Ok(user);
        }
    }
}
