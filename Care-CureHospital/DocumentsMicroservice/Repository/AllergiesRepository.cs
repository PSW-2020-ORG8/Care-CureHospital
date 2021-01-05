using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Repository.MySQL;
using DocumentsMicroservice.Repository.MySQL.Stream;

namespace DocumentsMicroservice.Repository
{
    public class AllergiesRepository : MySQLRepository<Allergies, int>, IAllergiesRepository
    {
        public AllergiesRepository(IMySQLStream<Allergies> stream)
            : base(stream)
        {
        }
    }
}
