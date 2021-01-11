
using ProtocolMicroservice.Domain;
using System;

namespace ProtocolMicroservice.Service
{
    public interface IUrgentOrderService : IService<UrgentMedicineOrder, int>
    {
        String SendRequestForOrder(UrgentMedicineOrder medicineOrder);
    }
}
