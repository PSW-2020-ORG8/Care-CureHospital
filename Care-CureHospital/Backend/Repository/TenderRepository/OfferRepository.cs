using Backend.Model.Tender;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Repository.IDSequencer;

namespace Backend.Repository.TenderRepository
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

        public OfferRepository(IMySQLStream<Offer> stream, ISequencer<int> sequencer) : base(stream, sequencer)
        {

        }
    }
}
