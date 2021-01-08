using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderMicroservice.Domain;
using TenderMicroservice.Repository.MySQL;
using TenderMicroservice.Repository.MySQL.Stream;

namespace TenderMicroservice.Repository
{
    public class TenderRepository : MySQLRepository<Tender, int>, ITenderRepository
    {
        private static TenderRepository instance;

        public static TenderRepository Instance()
        {
            if (instance == null)
            {
                instance = new TenderRepository(new MySQLStream<Tender>());
            }
            return instance;
        }

        public TenderRepository(IMySQLStream<Tender> stream) : base(stream)
        {

        }
    }
}
