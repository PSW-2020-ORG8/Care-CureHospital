using UserMicroservice.Repository;

namespace UserMicroservice.Domain
{
    public class Specialitation : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string SpecialitationForDoctor { get; set; }

        public Specialitation()
        {
        }


        public int GetId() => Id;


        public void SetId(int id) => Id = id;

    }
}
