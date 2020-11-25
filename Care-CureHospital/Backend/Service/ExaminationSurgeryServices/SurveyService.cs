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

        
       
    }
}
