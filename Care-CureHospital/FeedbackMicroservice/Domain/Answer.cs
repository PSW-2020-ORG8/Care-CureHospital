using FeedbackMicroservice.Repository;


namespace FeedbackMicroservice.Domain
{
    public class Answer : IIdentifiable<int>
    {
        public int Id { get; set; }
        public GradeOfQuestion Grade { get; set; }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }

        public Answer(int id)
        {
            Id = id;
        }

        public Answer()
        {
        }

        public Answer(int id, GradeOfQuestion grade, int questionId, int surveyId) : this(id)
        {
            Grade = grade;
            QuestionId = questionId;
            SurveyId = surveyId;
        }

        public Answer(int questionId, GradeOfQuestion grade)
        {
            Grade = grade;
            QuestionId = questionId;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}

