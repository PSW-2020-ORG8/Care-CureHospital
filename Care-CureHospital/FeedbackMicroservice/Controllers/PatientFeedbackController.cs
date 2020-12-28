using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.AllActors;
using Backend.Model.BlogAndNotification;
using FeedbackMicroservice.Dto;
using FeedbackMicroservice.Mapper;
using FeedbackMicroservice.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackMicroservice.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbackController : ControllerBase
    {
        private IPatientFeedbackService patientFeedbackService;

        public PatientFeedbackController(IPatientFeedbackService patientFeedbackService) 
        {
            this.patientFeedbackService = patientFeedbackService;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]       // GET /api/patientFeedback
        public IActionResult GetAllFeedbacks()
        {
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();
            this.patientFeedbackService.GetAllEntities().ToList().ForEach(feedback => result.Add(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(feedback)));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("getPublishedFeedbacks")]       // GET /api/patientFeedback/getPublishedFeedbacks
        public IActionResult GetPublishedFeedbacks()
        {
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();
            this.patientFeedbackService.GetPublishedFeedbacks().ToList().ForEach(feedback => result.Add(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(feedback)));
            return Ok(result);
        }

        [Authorize(Roles = Role.Patient)]
        [HttpPost]      // POST /api/patientFeedback
        public IActionResult Add(PatientFeedbackDto dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }
            PatientFeedback patientFeedback = PatientFeedbackMapper.PatientFeedbackDtoToPatientFeedback(dto, null);
            this.patientFeedbackService.AddEntity(patientFeedback);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("publishFeedback/{id}")]       // PUT /api/patientFeedback/publishFeedback/{id}
        public IActionResult PublishFeedback(int id)
        {
            PatientFeedback result = this.patientFeedbackService.PublishPatientFeedback(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(result));
        }
    }
}
