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
    public class SurveyController : ControllerBase
    {
        private ISurveyService surveyService;
        private IAnswerService answerService;
        private IDoctorGateway doctorGateway;
        private IAppointmentGateway appointmentGateway;
        private IDomainEventService domainEventService;

        public SurveyController(ISurveyService surveyService, IAnswerService answerService, IDoctorGateway doctorGateway, IAppointmentGateway appointmentGateway, IDomainEventService domainEventService) 
        {
            this.surveyService = surveyService;
            this.answerService = answerService;
            this.doctorGateway = doctorGateway;
            this.appointmentGateway = appointmentGateway;
            this.domainEventService = domainEventService;
        }

        [HttpGet] // GET /api/survey
        public IActionResult GetAllSurveys()
        {
            domainEventService.Save(new URLEvent("/api/survey", "GET"));
            List<SurveyDto> result = new List<SurveyDto>();
            this.surveyService.GetAllEntities().ToList().ForEach(survey => result.Add(SurveyMapper.SurveyToSurveyDto(survey)));
            return Ok(result);
        }

        [HttpGet("getSurveyResults")] // GET /api/survey/getSurveyResults
        public IActionResult GetSurveyResults()
        {
            domainEventService.Save(new URLEvent("/api/survey/getSurveyResults", "GET"));
            return Ok(QuestionResultMapper.CreateQuestionResultsDto(this.answerService.GetAnswersByQuestion()));
        }

        [HttpGet("getSurveyResultsForDoctors")] // GET /api/survey/getSurveyResultsForDoctors
        public IActionResult GetSurveyResultsForDoctors()
        {
            domainEventService.Save(new URLEvent("/api/survey/getSurveyResultsForDoctors", "GET"));
            return Ok(QuestionResultMapper.CreateDoctorResultsDto(this.surveyService.GetSurveyResultsForAllDoctors(), doctorGateway.GetAllDoctors()));
        }

        [HttpPut("filledSurveyForAppointment/{appointmentId}")]       // GET /api/survey/filledSurveyForAppointment/{appointmentId}
        public IActionResult FilledSurveyForAppointment(int appointmentId)
        {
            domainEventService.Save(new URLEvent("filledSurveyForAppointment/" + appointmentId, "PUT"));
            appointmentGateway.FilledSurveyForAppointment(appointmentId);
            return Ok();
        }

        [HttpPost]      // POST /api/survey
        public IActionResult AddSurvey(SurveyDto dto)
        {
            domainEventService.Save(new URLEvent("/api/survey", "POST"));
            Survey survey = SurveyMapper.SurveyDtoToSurvey(dto);
            this.surveyService.AddEntity(survey);
            return Ok();
        }
    }
}
