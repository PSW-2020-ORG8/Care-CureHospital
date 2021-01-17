using ProtocolMicroservice.Repository;
using System;

namespace ProtocolMicroservice.Domain
{
    public class UrgentMedicineOrder : IIdentifiable<int>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }

        public UrgentMedicineOrder() { }

        public UrgentMedicineOrder(int id, string name, int quantity) 
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public UrgentMedicineOrder(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public int GetName()
        {
            throw new NotImplementedException();
        }

        public void SetName(int Name)
        {
            throw new NotImplementedException();
        }
    }
}
