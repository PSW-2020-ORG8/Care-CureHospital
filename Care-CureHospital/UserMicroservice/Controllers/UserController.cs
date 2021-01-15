using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using UserMicroservice.Domain;
using UserMicroservice.Dto;
using UserMicroservice.Service;

namespace UserMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IPatientService patientService;
        private readonly AppSettings appSettings;
        private readonly IDomainEventService eventService;
        public UserController(IUserService userService, IPatientService patientService, IOptions<AppSettings> appSettings, IDomainEventService eventService)
        {
            this.userService = userService;
            this.patientService = patientService;
            this.appSettings = appSettings.Value;
            this.eventService = eventService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateDto model)
        {
            eventService.Save(new URLEvent("/api/user/login", "GET"));
            User user = userService.Authenticate(model.Username, model.Password, Encoding.ASCII.GetBytes(appSettings.Secret));
            if (user == null)
            {
                return Unauthorized();
            } 

            if (user is Patient)
            {
                if (patientService.GetPatientByUsername(model.Username).isBlocked())
                {
                    return Unauthorized();
                }
            }
            eventService.Save(new LoginEvent(user.AccountInfo.Username,user.Id));
            return Ok(user);
        }
    }
}
