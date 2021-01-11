using ProtocolMicroservice.Domain;

namespace ProtocolMicroservice.Repository
{
    public interface IProtocolRepository : IRepository<UrgentMedicineOrder, int>
    {
    }
}
