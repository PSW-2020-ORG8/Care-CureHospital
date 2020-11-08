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
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();
            App.Instance().patientFeedbackService.GetAllEntities().ToList().ForEach(feedback => result.Add(PatientFeedbackAdapter.PatientFeedbackToPatientFeedbackDto(feedback)));
            return Ok(result);
        }

        
        [HttpGet("getPublishedFeedbacks")]       // GET /api/patientFeedback/getPublishedFeedbacks
        public IActionResult GetPublishedFeedbacks()
        {
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();
            App.Instance().patientFeedbackService.GetPublishedFeedbacks().ToList().ForEach(feedback => result.Add(PatientFeedbackAdapter.PatientFeedbackToPatientFeedbackDto(feedback)));
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

        /// <summary>This method changes status of <c>PatientFeedback</c> into published Feedback <c>isPublished<c>></summary>
        /// <param name="id"> id of PatientFeedback</param>
        /// <returns> changed <c>PatientFeedbackDto</c> object</returns>
        [HttpPut("publishFeedback/{id}")]       // PUT /api/patientFeedback/publishFeedback/{id}
        public IActionResult PublishFeedback(int id)
        {     
            PatientFeedback result = App.Instance().patientFeedbackService.PublishPatientFeedback(id);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(PatientFeedbackAdapter.PatientFeedbackToPatientFeedbackDto(result));
        }
        
        
    }
}
