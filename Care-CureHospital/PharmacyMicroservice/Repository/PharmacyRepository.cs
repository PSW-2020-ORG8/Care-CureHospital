using PharmacyMicroservice.Domain;
using PharmacyMicroservice.Repository.MySQL;
using PharmacyMicroservice.Repository.MySQL.Stream;

namespace PharmacyMicroservice.Repository
{
    public class PharmacyRepository : MySQLRepository<Pharmacies, int>, IPharmacyRepository
    {
        public PharmacyRepository(IMySQLStream<Pharmacies> stream)
            : base(stream)
        {
        }
    }
}
