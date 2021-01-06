using DocumentsMicroservice.Repository;

namespace DocumentsMicroservice.Domain
{
    public class Diagnosis : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnamnesisId { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }

        public Diagnosis()
        {
        }

        public Diagnosis(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public Diagnosis(int id, string name, int anamnesisID) : this(id, name)
        {
            AnamnesisId = anamnesisID;
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
