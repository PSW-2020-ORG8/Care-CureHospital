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
    public class SurveyController : ControllerBase
    {
        private ISurveyService surveyService;
        private IAnswerService answerService;
        private IDoctorGateway doctorGateway;
        private IAppointmentGateway appointmentGateway;

        public SurveyController(ISurveyService surveyService, IAnswerService answerService, IDoctorGateway doctorGateway, IAppointmentGateway appointmentGateway) 
        {
            this.surveyService = surveyService;
            this.answerService = answerService;
            this.doctorGateway = doctorGateway;
            this.appointmentGateway = appointmentGateway;
        }

        [HttpGet] // GET /api/survey
        public IActionResult GetAllSurveys()
        {
            List<SurveyDto> result = new List<SurveyDto>();
            this.surveyService.GetAllEntities().ToList().ForEach(survey => result.Add(SurveyMapper.SurveyToSurveyDto(survey)));
            return Ok(result);
        }

        [HttpGet("getSurveyResults")] // GET /api/survey/getSurveyResults
        public IActionResult GetSurveyResults()
        {
            return Ok(QuestionResultMapper.CreateQuestionResultsDto(this.answerService.GetAnswersByQuestion()));
        }

        [HttpGet("getSurveyResultsForDoctors")] // GET /api/survey/getSurveyResultsForDoctors
        public IActionResult GetSurveyResultsForDoctors()
        {
            return Ok(QuestionResultMapper.CreateDoctorResultsDto(this.surveyService.GetSurveyResultsForAllDoctors(), doctorGateway.GetAllDoctors()));
        }

        [HttpPut("filledSurveyForAppointment/{appointmentId}")]       // GET /api/survey/filledSurveyForAppointment/{appointmentId}
        public IActionResult FilledSurveyForAppointment(int appointmentId)
        {
            appointmentGateway.FilledSurveyForAppointment(appointmentId);
            return Ok();
        }

        [HttpPost]      // POST /api/survey
        public IActionResult AddSurvey(SurveyDto dto)
        {
            Survey survey = SurveyMapper.SurveyDtoToSurvey(dto);
            this.surveyService.AddEntity(survey);
            return Ok();
        }
    }
}
