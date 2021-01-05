using AppointmentMicroservice.Repository;

namespace AppointmentMicroservice.Domain
{
    public class TypeOfRoom : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string NameOfType { get; set; }

        public TypeOfRoom()
        {
        }

        public TypeOfRoom(string nameOfType)
        {
            NameOfType = nameOfType;
        }

        public TypeOfRoom(int id, string nameOfType)
        {
            Id = id;
            NameOfType = nameOfType;
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
