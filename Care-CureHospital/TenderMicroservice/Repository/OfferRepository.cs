using TenderMicroservice.Domain;
using TenderMicroservice.Repository.MySQL;
using TenderMicroservice.Repository.MySQL.Stream;

namespace TenderMicroservice.Repository
{
    public class OfferRepository : MySQLRepository<Offer, int>, IOfferRepository
    {
        public OfferRepository(IMySQLStream<Offer> stream)
            : base(stream)
        {
        }
    }
}
