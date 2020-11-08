using Backend.Model.BlogAndNotification;
using Backend.Repository.BlogNotificationRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Service.BlogNotificationServices
{
    public class PatientFeedbackService : IService<PatientFeedback, int>
    {
        public IPatientFeedbackRepository patientFeedbackRepository;
        public PatientFeedbackService(IPatientFeedbackRepository patientFeedbackRepository)
        {
            this.patientFeedbackRepository = patientFeedbackRepository;
        }
        public PatientFeedback AddEntity(PatientFeedback entity)
        {
            entity.PublishingDate = DateTime.Now;
            return patientFeedbackRepository.AddEntity(entity);
        }

        public void DeleteEntity(PatientFeedback entity)
        {
            patientFeedbackRepository.DeleteEntity(entity);
        }

        public IEnumerable<PatientFeedback> GetAllEntities()
        {
            return patientFeedbackRepository.GetAllEntities();
        }

        public PatientFeedback GetEntity(int id)
        {
            return patientFeedbackRepository.GetEntity(id);
        }

        public void UpdateEntity(PatientFeedback entity)
        {
            patientFeedbackRepository.UpdateEntity(entity);
        }

        public IEnumerable<PatientFeedback> GetPublishedFeedbacks()
        {
            return patientFeedbackRepository.GetAllEntities().Where(patientFeedback => patientFeedback.IsPublished.Equals(true));
        }

        public PatientFeedback PublishPatientFeedback(int id)
        {
            PatientFeedback patientFeedback = patientFeedbackRepository.GetEntity(id);
            
            if (patientFeedback == null)
                return null;
            
            patientFeedback.IsPublished = true;
            patientFeedbackRepository.UpdateEntity(patientFeedback);
            return patientFeedback;
        }
    }
}
