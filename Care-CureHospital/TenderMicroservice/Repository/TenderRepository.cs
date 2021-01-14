using TenderMicroservice.Domain;
using TenderMicroservice.Repository.MySQL;
using TenderMicroservice.Repository.MySQL.Stream;

namespace TenderMicroservice.Repository
{
    public class TenderRepository : MySQLRepository<Tender, int>, ITenderRepository
    {
        public TenderRepository(IMySQLStream<Tender> stream)
            : base(stream)
        {
        }
    }
}
