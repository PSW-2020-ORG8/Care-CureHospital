using System.Collections.Generic;
using System.Linq;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
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
        private IDomainEventService domainEventService;

        public PatientFeedbackController(IPatientFeedbackService patientFeedbackService, IPatientGateway patientGateway, IDomainEventService domainEventService) 
        {
            this.patientFeedbackService = patientFeedbackService;
            this.patientGateway = patientGateway;
            this.domainEventService = domainEventService;
        }

        [HttpGet]       // GET /api/patientFeedback
        public IActionResult GetAllFeedbacks()
        {
            domainEventService.Save(new URLEvent("/api/patientFeedback", "GET"));
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();           
            this.patientFeedbackService.GetAllEntities().ToList().ForEach(feedback => result.Add(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(feedback, patientGateway.GetPatientById(feedback.PatientId))));
            return Ok(result);
        }

        [HttpGet("getPublishedFeedbacks")]       // GET /api/patientFeedback/getPublishedFeedbacks
        public IActionResult GetPublishedFeedbacks()
        {
            domainEventService.Save(new URLEvent("/api/patientFeedback/getPublishedFeedbacks", "GET"));
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();
            this.patientFeedbackService.GetPublishedFeedbacks().ToList().ForEach(feedback => result.Add(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(feedback, patientGateway.GetPatientById(feedback.PatientId))));
            return Ok(result);
        }

        [HttpPost("postPatientFeedback")]      // POST /api/patientFeedback/postPatientFeedback
        public IActionResult Add(PatientFeedbackDto dto)
        {
            domainEventService.Save(new URLEvent("/api/patientFeedback/postPatientFeedback", "POST"));
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
            domainEventService.Save(new URLEvent("/api/publishFeedback/" + id, "PUT"));
            PatientFeedback result = this.patientFeedbackService.PublishPatientFeedback(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(result, patientGateway.GetPatientById(result.PatientId)));
        }
    }
}
