using System;

namespace ProtocolMicroservice.Dto
{
    public class UrgentMedicineOrderDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }

        public UrgentMedicineOrderDto() { }

        public UrgentMedicineOrderDto(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}