using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;


namespace FeedbackMicroservice.Repository
{
    class QuestionRepository : MySQLRepository<Question, int>, IQuestionRepository
    {
        public QuestionRepository(IMySQLStream<Question> stream)
            : base(stream)
        {
        }
    }
}
