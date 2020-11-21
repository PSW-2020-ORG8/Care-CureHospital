using Backend.Repository.ExaminationSurgeryRepository;
using Model.Patient;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class QuestionService : IService<Question, int>
    {

        public IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public Question AddEntity(Question entity)
        {
            return questionRepository.AddEntity(entity);
        }

        public void DeleteEntity(Question entity)
        {
            questionRepository.DeleteEntity(entity);
        }

        public IEnumerable<Question> GetAllEntities()
        {
            return questionRepository.GetAllEntities();
        }

        public Question GetEntity(int id)
        {
            return questionRepository.GetEntity(id);
        }

        public void UpdateEntity(Question entity)
        {
            questionRepository.UpdateEntity(entity);
        }

        public Dictionary<string, List<int>> GetAnswersByQuestion()
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
