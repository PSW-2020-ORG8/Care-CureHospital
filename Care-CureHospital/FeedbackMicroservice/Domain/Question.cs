using FeedbackMicroservice.Repository;


namespace FeedbackMicroservice.Domain
{
    public class Question : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }

        public Question(int id)
        {
            Id = id;
        }

        public Question()
        {
        }

        public Question(int id, string questionText, QuestionType questionType) : this(id)
        {
            QuestionText = questionText;
            QuestionType = questionType;
        }

        public Question(string questionText)
        {
            QuestionText = questionText;
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
