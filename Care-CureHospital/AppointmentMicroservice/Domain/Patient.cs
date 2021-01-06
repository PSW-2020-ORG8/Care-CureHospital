using AppointmentMicroservice.Repository;

namespace AppointmentMicroservice.Domain
{
    public class Patient : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Malicious { get; set; }

        public Patient()
        {
        }

        public Patient(string name, string surname, bool malicious)
        {
            Name = name;
            Surname = surname;
            Malicious = malicious;
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
