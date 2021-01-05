using Backend.Model.Tender;
using Backend.Repository.TenderRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Service.TenderService
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
            entity.ActiveTender = true;
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
            throw new NotImplementedException();
        }

        public void UpdateEntity(Offer entity)
        {
            throw new NotImplementedException();
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
