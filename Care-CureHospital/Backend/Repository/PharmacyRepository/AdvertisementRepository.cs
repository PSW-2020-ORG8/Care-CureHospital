using Backend.Model.Pharmacy;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Repository.IDSequencer;

namespace Backend.Repository.PharmacyRepository
{
    public class AdvertisementRepository : MySQLRepository<Advertisement, int>, IAdvertisementRepository
    {
        public AdvertisementRepository(IMySQLStream<Advertisement> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}
