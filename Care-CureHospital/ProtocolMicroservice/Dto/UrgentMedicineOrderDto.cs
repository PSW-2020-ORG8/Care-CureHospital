using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
