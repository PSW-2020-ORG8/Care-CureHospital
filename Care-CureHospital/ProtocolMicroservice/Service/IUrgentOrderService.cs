using ProtocolMicroservice.Domain;

namespace ProtocolMicroservice.Service
{
    public interface IUrgentOrderService : IService<UrgentMedicineOrder, int>
    {
        string SendRequestForOrder(UrgentMedicineOrder medicineOrder);
    }
}