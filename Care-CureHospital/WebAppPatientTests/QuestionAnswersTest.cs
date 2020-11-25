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
    public class QuestionAnswersTest
    {
        [Fact]
        public void Get_survey_results()
        {
            QuestionService questionService = new QuestionService(CreateStubRepository());

            Dictionary<string, List<int>> results = questionService.GetAnswersByQuestion();

            Assert.NotNull(results);
        }

        [Fact]
        public void Validate_survey_results()
        {
            QuestionService questionService = new QuestionService(CreateStubRepository());

            Dictionary<string, List<int>> results = questionService.GetAnswersByQuestion();

            Assert.Equal(5, results.Keys.Count);
        }

        private static IQuestionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IQuestionRepository>();

            var questions = new List<Question>();
            Survey survey1 = new Survey(1);
            Survey survey2 = new Survey(2);
            questions.Add(new Question(1, "Pitanje1", GradeOfQuestion.Fair, 1, null));
            questions.Add(new Question(2, "Pitanje2", GradeOfQuestion.Excellent, 1, null));
            questions.Add(new Question(3, "Pitanje3", GradeOfQuestion.Poor, 1, null));
            questions.Add(new Question(4, "Pitanje4", GradeOfQuestion.Good, 1, null));
            questions.Add(new Question(5, "Pitanje5", GradeOfQuestion.Fair, 1, null));
            questions.Add(new Question(6, "Pitanje1", GradeOfQuestion.Good, 2, null));
            questions.Add(new Question(7, "Pitanje2", GradeOfQuestion.Excellent, 2, null));
            questions.Add(new Question(8, "Pitanje3", GradeOfQuestion.VeryGood, 2, null));
            questions.Add(new Question(9, "Pitanje4", GradeOfQuestion.Good, 2, null));
            questions.Add(new Question(10, "Pitanje5", GradeOfQuestion.Excellent, 2, null));

            stubRepository.Setup(questionRepository => questionRepository.GetAllEntities()).Returns(questions);
            return stubRepository.Object;
        }
    }
}
