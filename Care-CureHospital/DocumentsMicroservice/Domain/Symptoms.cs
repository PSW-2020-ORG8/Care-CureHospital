using DocumentsMicroservice.Repository;

namespace DocumentsMicroservice.Domain
{
    public class Symptoms : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnamnesisId { get; set; }

        public Symptoms()
        {
        }

        public Symptoms(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public Symptoms(string name)
        {
            Name = name;
        }

        public Symptoms(int id, string name, int anamnesisID) : this(id, name)
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
