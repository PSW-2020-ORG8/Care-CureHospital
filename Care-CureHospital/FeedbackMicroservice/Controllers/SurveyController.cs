using System.Collections.Generic;
using System.Linq;
using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Dto;
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
       

        public SurveyController(ISurveyService surveyService, IAnswerService answerService) 
        {
            this.surveyService = surveyService;
            this.answerService = answerService;
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

    /*   [HttpGet("getSurveyResultsForDoctors")] // GET /api/survey/getSurveyResultsForDoctors
        public IActionResult GetSurveyResultsForDoctors()
        {
            return Ok(QuestionResultMapper.CreateDoctorResultsDto(this.surveyService.GetSurveyResultsForAllDoctors(), App.Instance().DoctorService.GetAllEntities()));
        }*/

      /*  [HttpPut("filledSurveyForAppointment/{appointmentId}")]       // GET /api/survey/filledSurveyForAppointment/{appointmentId}
        public IActionResult FilledSurveyForAppointment(int appointmentId)
        {
            return Ok(this.appointmentService.FilledSurveyForAppointment(appointmentId));
        }*/

        [HttpPost]      // POST /api/survey
        public IActionResult AddSurvey(SurveyDto dto)
        {
            Survey survey = SurveyMapper.SurveyDtoToSurvey(dto);
            this.surveyService.AddEntity(survey);
            return Ok();
        }
    }
}
