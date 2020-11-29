using Backend.Repository.ExaminationSurgeryRepository;
using Model.Patient;
using Service;
using Service.ExaminationSurgeryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class SurveyService : IService<Survey, int>
    {
        public ISurveyRepository surveyRepository;

        public MedicalExaminationService medicalExaminationService;
        public AnswerService answerService;

        public SurveyService(ISurveyRepository surveyRepository, MedicalExaminationService medicalExaminationService, AnswerService answerService)
        {
            this.surveyRepository = surveyRepository;
            this.medicalExaminationService = medicalExaminationService;
            this.answerService = answerService;
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

        public Dictionary<int, List<int>> GetSurveyIdsForDoctorIds()
        {
            Dictionary<int, List<int>> results = new Dictionary<int, List<int>>();
            foreach (Survey survey in GetAllEntities())
            {
                int doctorId = medicalExaminationService.GetEntity(survey.MedicalExaminationId).DoctorId;
                if (!results.ContainsKey(doctorId))
                {
                    results.Add(doctorId, new List<int>());
                }
                results[doctorId].Add(survey.Id);
            }
            return results;
        }

        public Dictionary<int, Dictionary<int, List<int>>> GetSurveyResultsForAllDoctors()
        {
            Dictionary<int, Dictionary<int, List<int>>> result = new Dictionary<int, Dictionary<int, List<int>>>();
            Dictionary<int, List<int>> surveyIdsForDoctorIds = GetSurveyIdsForDoctorIds();
            foreach (int doctorId in surveyIdsForDoctorIds.Keys)
            {
                result.Add(doctorId, answerService.GetAnswersForDoctorBySurveyIds(surveyIdsForDoctorIds[doctorId]));
            }
            return result;
        }
       
    }
}
