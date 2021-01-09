using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class AdvertisementRepository : MySQLRepository<Advertisement, int>, IAdvertisementRepository
    {
        public AdvertisementRepository(IMySQLStream<Advertisement> stream)
            : base(stream)
        {
        }
    }
}
