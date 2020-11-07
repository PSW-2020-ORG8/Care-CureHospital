using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Adapters;
using Backend.Dto;
using Backend.Model.BlogAndNotification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbackController : ControllerBase
    {

        public PatientFeedbackController() {}

        [HttpGet]       // GET /api/patientFeedback
        public IActionResult GetAllFeedbacks()
        {
            List<PatientFeedback> result = new List<PatientFeedback>();
            App.Instance().patientFeedbackService.GetAllEntities().ToList().ForEach(feedback => result.Add(feedback));
            return Ok(result);
        }

        
        [HttpGet("getPublishedFeedbacks")]       // GET /api/patientFeedback/getPublishedFeedbacks
        public IActionResult GetPublishedFeedbacks()
        {
            List<PatientFeedback> result = new List<PatientFeedback>();
            App.Instance().patientFeedbackService.GetPublishedFeedbacks().ToList().ForEach(feedback => result.Add(feedback));
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add(PatientFeedbackDto dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            PatientFeedback patientFeedback = PatientFeedbackAdapter.PatientFeedbackDtoToPatientFeedback(dto, null);
            App.Instance().patientFeedbackService.AddEntity(patientFeedback);
            return Ok();
        }

        [HttpPut("publishFeedback/{id}")]       // PUT /api/patientFeedback/publishFeedback/{id}
        public IActionResult PublishFeedback(int id)
        {
            if (id < 0)
                return BadRequest();
            
            PatientFeedback result = App.Instance().patientFeedbackService.PublishPatientFeedback(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        
    }
}
