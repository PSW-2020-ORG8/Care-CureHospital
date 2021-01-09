using AppointmentMicroservice.Repository;

namespace AppointmentMicroservice.Domain
{
    public class Doctor : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SpecialitationId { get; set; }
        public Specialitation Specialitation { get; set; }

        public Doctor(string name, string surname, string username, int specialitationId, Specialitation specialitation)
        {
            Name = name;
            Surname = surname;
            Username = username;
            SpecialitationId = specialitationId;
            Specialitation = specialitation;
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
