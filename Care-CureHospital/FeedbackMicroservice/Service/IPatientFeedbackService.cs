using FeedbackMicroservice.Domain;
using System.Collections.Generic;


namespace FeedbackMicroservice.Service
{
    public interface IPatientFeedbackService : IService<PatientFeedback, int>
    {
        public IEnumerable<PatientFeedback> GetPublishedFeedbacks();
        public PatientFeedback PublishPatientFeedback(int id);
    }
}
