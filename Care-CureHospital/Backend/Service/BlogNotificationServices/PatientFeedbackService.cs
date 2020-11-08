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

        /// <summary> This method calls <c>PatientFeedbackRepository</c> to post new <c>PatientFeedback</c>. </summary>
        /// <param name="entity"> Entity of type <c>PatientFeedback</c>. </param>
        /// <returns> Entity of type <c>PatientFeedback</c>. </returns>
        public PatientFeedback AddEntity(PatientFeedback entity)
        {
            entity.PublishingDate = DateTime.Now;
            return patientFeedbackRepository.AddEntity(entity);
        }

        public void DeleteEntity(PatientFeedback entity)
        {
            patientFeedbackRepository.DeleteEntity(entity);
        }

        /// <summary> This method calls <c>PatientFeedbackRepository</c> to get list of all <c>PatientFeedback</c>. </summary>
        /// <returns> List of all feedbacks. </returns>
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

        /// <summary> This method calls <c>PatientFeedbackRepository</c> to get list of <c>PatientFeedback</c> where paramter <c>IsPublished</c> is true. </summary>
        /// <returns> List of published feedbacks. </returns>
        public IEnumerable<PatientFeedback> GetPublishedFeedbacks()
        {
            return patientFeedbackRepository.GetAllEntities().Where(patientFeedback => patientFeedback.IsPublished.Equals(true));
        }

        /// <summary>This method calls <c>PatientFeedbackRepository</c> to change satus of <c>PatientFeedback</c> atribute <c>isPublished</c> on True></summary>
        /// <param name="id"> id of PatientFeedback</param>
        /// <returns> changed <c>PatientFeedback</c> object</returns>
        public PatientFeedback PublishPatientFeedback(int id)
        {
            PatientFeedback patientFeedback = patientFeedbackRepository.GetEntity(id);
            
            if (patientFeedback == null)
            {
                return null;
            }       
            
            patientFeedback.IsPublished = true;
            patientFeedbackRepository.UpdateEntity(patientFeedback);
            return patientFeedback;
        }
    }
}
