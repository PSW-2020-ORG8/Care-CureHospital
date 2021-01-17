using System.Collections.Generic;
using TenderMicroservice.Domain;

namespace TenderMicroservice.Service
{
    public interface ITenderService : IService<Tender, int>
    {
        Tender CloseTender(int tenderId);
        public IEnumerable<Tender> GetActiveTenders();
        public IEnumerable<Tender> GetInactiveTenders();
    }
}