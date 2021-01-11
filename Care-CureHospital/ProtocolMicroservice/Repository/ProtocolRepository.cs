using ProtocolMicroservice.Domain;
using ProtocolMicroservice.Repository.MySQL;
using ProtocolMicroservice.Repository.MySQL.Stream;


namespace ProtocolMicroservice.Repository
{
    public class ProtocolRepository : MySQLRepository<UrgentMedicineOrder, int>, IProtocolRepository
    {
        public ProtocolRepository(IMySQLStream<UrgentMedicineOrder> stream)
            : base(stream)
        {
        }
    }
}
