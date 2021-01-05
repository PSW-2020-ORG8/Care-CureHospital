using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Repository.MySQL;
using DocumentsMicroservice.Repository.MySQL.Stream;

namespace DocumentsMicroservice.Repository
{
    public class PrescriptionRepository : MySQLRepository<Prescription, int>, IPrescriptionRepository
    {
        public PrescriptionRepository(IMySQLStream<Prescription> stream)
            : base(stream)
        {
        }
    }
}
