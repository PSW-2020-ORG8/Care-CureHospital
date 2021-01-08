using DocumentsMicroservice.Repository;

namespace DocumentsMicroservice.Domain
{
    public class Allergies : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicalRecordId { get; set; }

        public Allergies()
        {
        }

        public Allergies(string name)
        {
            Name = name;
        }

        public Allergies(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public Allergies(int id, string name, int medicalRecordID) : this(id, name)
        {
            MedicalRecordId = medicalRecordID;
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
