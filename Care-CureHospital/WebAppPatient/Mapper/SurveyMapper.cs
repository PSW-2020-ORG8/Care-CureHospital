using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class SurveyMapper
    {
        public static Survey SurveyDtoToSurvey(SurveyDto dto, Survey patient)
        {
            Survey survey = new Survey();

            survey.Title = dto.Title;
            survey.CommentSurvey = dto.CommentSurvey;
            survey.PublishingDate = dto.PublishingDate;
            survey.Questions = dto.Questions;

            return survey;
        }

        public static SurveyDto SurveyToSurveyDto(Survey survey)
        {
            SurveyDto dto = new SurveyDto();

            dto.Title = survey.Title;
            dto.CommentSurvey = survey.CommentSurvey;
            dto.PublishingDate = survey.PublishingDate;
            dto.Questions = new List<Question>();
            foreach(Question question in survey.Questions)
            {
                dto.Questions.Add(new Question(question.QuestionText, question.Answer));
            }

            return dto;
        }
    }
}
