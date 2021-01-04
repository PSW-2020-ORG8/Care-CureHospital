using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;


namespace FeedbackMicroservice.Repository
{
    public class AnswerRepository : MySQLRepository<Answer, int>, IAnswerRepository
    {
        public AnswerRepository(IMySQLStream<Answer> stream)
            : base(stream)
        {
        }

    }
}
