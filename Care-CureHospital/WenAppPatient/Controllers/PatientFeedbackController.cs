using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Model;

namespace WenAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbackController : ControllerBase
    {
        private readonly HealthClinicDbContext dbContext;
        public PatientFeedbackController(HealthClinicDbContext context)
        {
            this.dbContext = context;
        }

        [HttpPost]
        public IActionResult Add(PatientFeedbackDto dto)
        {
            if (dto.text.Length <= 0)
            {
                return BadRequest();
            }

            PatientFeedback patientFeedback = PatientFeedbackAdapter.PatientFeedbackDtoToPatientFeedback(dto);
            dbContext.PatientFeedbacks.Add(patientFeedback);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
