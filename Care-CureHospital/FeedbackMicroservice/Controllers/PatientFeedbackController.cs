using System.Collections.Generic;
using System.Linq;
using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Dto;
using FeedbackMicroservice.Gateway.Interface;
using FeedbackMicroservice.Mapper;
using FeedbackMicroservice.Service;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbackController : ControllerBase
    {
        private IPatientFeedbackService patientFeedbackService;
        private IPatientGateway patientGateway;

        public PatientFeedbackController(IPatientFeedbackService patientFeedbackService, IPatientGateway patientGateway) 
        {
            this.patientFeedbackService = patientFeedbackService;
            this.patientGateway = patientGateway;
        }

        [HttpGet]       // GET /api/patientFeedback
        public IActionResult GetAllFeedbacks()
        {
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();           
            this.patientFeedbackService.GetAllEntities().ToList().ForEach(feedback => result.Add(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(feedback, patientGateway.GetPatientById(feedback.PatientId))));
            return Ok(result);
        }

        [HttpGet("getPublishedFeedbacks")]       // GET /api/patientFeedback/getPublishedFeedbacks
        public IActionResult GetPublishedFeedbacks()
        {
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();
            this.patientFeedbackService.GetPublishedFeedbacks().ToList().ForEach(feedback => result.Add(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(feedback, patientGateway.GetPatientById(feedback.PatientId))));
            return Ok(result);
        }

        [HttpPost]      // POST /api/patientFeedback
        public IActionResult Add(PatientFeedbackDto dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }
            PatientFeedback patientFeedback = PatientFeedbackMapper.PatientFeedbackDtoToPatientFeedback(dto);
            this.patientFeedbackService.AddEntity(patientFeedback);
            return Ok();
        }

        [HttpPut("publishFeedback/{id}")]       // PUT /api/patientFeedback/publishFeedback/{id}
        public IActionResult PublishFeedback(int id)
        {
            PatientFeedback result = this.patientFeedbackService.PublishPatientFeedback(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(result, patientGateway.GetPatientById(result.PatientId)));
        }
    }
}
