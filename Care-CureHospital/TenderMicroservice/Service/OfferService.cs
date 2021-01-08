using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderMicroservice.Service
{
    public class OfferService : IService<Offer, int>
    {
        public IOfferRepository offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public Offer AddEntity(Offer entity)
        {
            Tender tender = new Tender();
            entity.ActiveTender = true;
            if (tender.Id == 1)
            {
                entity.TenderId = 1;
            }
            else
            {
                entity.TenderId = 2;
            }
            return offerRepository.AddEntity(entity);
        }

        public void DeleteEntity(Offer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offer> GetAllEntities()
        {
            return offerRepository.GetAllEntities();
        }

        public Offer GetEntity(int id)
        {
            return offerRepository.GetEntity(id);
        }

        public void UpdateEntity(Offer entity)
        {
            offerRepository.UpdateEntity(entity);
        }

        public List<Offer> GetAllOffersForActiveTender()
        {
            return GetAllEntities().ToList().Where(offer => offer.ActiveTender.Equals(true)).ToList();
        }

        public List<Offer> GetAllOffersForInactiveTender()
        {
            return GetAllEntities().ToList().Where(offer => offer.ActiveTender.Equals(false)).ToList();
        }
    }
}
