using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;


namespace FeedbackMicroservice.Repository
{
    public class PatientFeedbackRepository : MySQLRepository<PatientFeedback, int>, IPatientFeedbackRepository
    {

        public PatientFeedbackRepository(IMySQLStream<PatientFeedback> stream) :
            base(stream)
        {
        }
    }
}
