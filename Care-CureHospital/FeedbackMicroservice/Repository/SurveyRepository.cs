using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;


namespace FeedbackMicroservice.Repository
{
    public class SurveyRepository : MySQLRepository<Survey, int>, ISurveyRepository
    {
        public SurveyRepository(IMySQLStream<Survey> stream)
            : base(stream)
        {
        }
    }
}
