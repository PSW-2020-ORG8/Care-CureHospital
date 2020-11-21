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

        public SurveyService(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
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

       /* public void GetSurveyResults()
        {
            Dictionary<int, Dictionary<int, int>> results = new Dictionary<int, Dictionary<int, int>>();
            foreach (Survey survey in surveyRepository.GetAllEntities())
            {
                for (int i = 0; i < survey.Questions.Count; i++)
                {
                    int grade = (int)survey.Questions[i].Answer;
                    if (results[i].ContainsKey(grade))
                    {
                        results[i][grade] = results[i][grade] + 1;
                    }
                    else
                    {
                        results[i].Add(grade, 1);
                    }
                }
            }
        }
       */
    }
}
