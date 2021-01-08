using System.Text;
using Backend.Model.AllActors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

        public UserController(IUserService userService, IPatientService patientService, IOptions<AppSettings> appSettings)
        {
            this.userService = userService;
            this.patientService = patientService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateDto model)
        {
            User user = userService.Authenticate(model.Username, model.Password, Encoding.ASCII.GetBytes(appSettings.Secret));
            Patient patient = patientService.GetPatientByUsername(model.Username);
            if (user == null || patient.Blocked == true)
            {
                return Forbid();
            }
            return Ok(user);
        }
    }
}
