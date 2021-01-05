using FeedbackMicroservice.Domain;
using System.Collections.Generic;


namespace FeedbackMicroservice.Service
{
    public interface IQuestionService : IService<Question, int>
    {
        public List<int> GetDoctorTypeQuestionsIds();
    }
}
