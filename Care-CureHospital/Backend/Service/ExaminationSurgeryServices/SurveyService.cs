using Backend.Repository.ExaminationSurgeryRepository;
using Model.Patient;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class SurveyService : IService<Survey, int>
    {
        public ISurveyRepository surveyRepository;
        public IQuestionRepository questionRepository;

        public SurveyService(ISurveyRepository surveyRepository, IQuestionRepository questionRepository)
        {
            this.surveyRepository = surveyRepository;
            this.questionRepository = questionRepository;
        }

        public Survey GetEntity(int id)
        {
            return surveyRepository.GetEntity(id);
        }

        public IEnumerable<Survey> GetAllEntities()
        {
            return surveyRepository.GetAllEntities();
        }

        public Survey AddEntity(Survey entity)
        {
            return surveyRepository.AddEntity(entity);
        }

        public void UpdateEntity(Survey entity)
        {
            surveyRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Survey entity)
        {
            surveyRepository.DeleteEntity(entity);
        }

        public Dictionary<string, List<int>> GetSurveyResults()
        {
            IEnumerable<Question> questions = questionRepository.GetAllEntities();
            Dictionary<string, List<int>> results = new Dictionary<string, List<int>>();
            foreach (Question question in questions)
            {
                if (!results.ContainsKey(question.QuestionText))
                {
                    results.Add(question.QuestionText, new List<int>() { 0, 0, 0, 0, 0 });
                }

                int grade = (int)question.Answer;

                results[question.QuestionText][grade]++;
            }

            return results;
        }
       
    }
}
