using ProtocolMicroservice.Domain;
using ProtocolMicroservice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtocolMicroservice.Mapper
{
    public class UrgentMedicineOrderMapper
    {
        public static UrgentMedicineOrderDto UrgentMedicineOrderToUrgentMedicineOrderDto(UrgentMedicineOrder urgent)
        {
            UrgentMedicineOrderDto dto = new UrgentMedicineOrderDto();
            dto.Id = urgent.Id;
            dto.Name = urgent.Name;
            dto.Quantity = urgent.Quantity;
            return dto;
        }

        public static UrgentMedicineOrder UrgentMedicineOrderDtoToUrgentMedicineOrder(UrgentMedicineOrderDto dto)
        {
            UrgentMedicineOrder urgent = new UrgentMedicineOrder();
            urgent.Id = dto.Id;
            urgent.Name = dto.Name;
            urgent.Quantity = dto.Quantity;
            return urgent;
        }
    }
}
