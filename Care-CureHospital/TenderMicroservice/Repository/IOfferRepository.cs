using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderMicroservice.Domain;

namespace TenderMicroservice.Repository
{
    public interface IOfferRepository : IRepository<Offer, int>
    {
    }
}
