using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Service.ExaminationSurgeryServices;
using Model.Patient;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WebAppPatientTests
{
    public class SurveyTests
    {
        [Fact]
        public void Post_survey()
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());

            Survey survey = surveyService.AddEntity(new Survey(1, "Naslov ankete 1", new DateTime(2020, 11, 6, 8, 30, 0), "Komentar ankete 1", new List<Question>()));

            Assert.NotNull(survey);
        }



        private static ISurveyRepository CreateStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();

            var surveys = new List<Survey>();
            surveys.Add(new Survey(1, "Naslov ankete 1", new DateTime(2020, 11, 6, 8, 30, 0), "Komentar ankete 1", new List<Question>()));
            surveys.Add(new Survey(2, "Naslov ankete 2", new DateTime(2020, 11, 9, 9, 30, 0), "Komentar ankete 2", new List<Question>()));
            surveys.Add(new Survey(3, "Naslov ankete 3", new DateTime(2020, 11, 11, 7, 30, 0), "Komentar ankete 3", new List<Question>()));


            stubRepository.Setup(surveyRepository => surveyRepository.GetAllEntities()).Returns(surveys);
            stubRepository.Setup(survey => survey.AddEntity(It.IsAny<Survey>())).Returns(new Survey(1, "Naslov ankete 1", new DateTime(2020, 11, 6, 8, 30, 0), "Komentar ankete 1", new List<Question>()));

            return stubRepository.Object;
        }


    }
}
