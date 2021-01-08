using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderMicroservice.Repository
{
    public class OfferRepository : MySQLRepository<Offer, int>, IOfferRepository
    {

        private static OfferRepository instance;

        public static OfferRepository Instance()
        {
            if (instance == null)
            {
                instance = new OfferRepository(new MySQLStream<Offer>(), new IntSequencer());
            }
            return instance;
        }

        public OfferRepository(IMySQLStream<Offer> stream) : base(stream)
        {

        }
    }
}
