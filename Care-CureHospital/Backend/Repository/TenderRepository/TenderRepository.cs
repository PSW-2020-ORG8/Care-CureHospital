using Backend.Model.Tender;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Repository.IDSequencer;

namespace Backend.Repository.TenderRepository
{
    public class TenderRepository : MySQLRepository<Tender, int>, ITenderRepository
    {
        private static TenderRepository instance;

        public static TenderRepository Instance()
        {
            if (instance == null)
            {
                instance = new TenderRepository(new MySQLStream<Tender>(), new IntSequencer());
            }
            return instance;
        }

        public TenderRepository(IMySQLStream<Tender> stream, ISequencer<int> sequencer) : base(stream, sequencer)
        {

        }
    }
}
