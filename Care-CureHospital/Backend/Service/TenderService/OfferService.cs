using Backend.Model.Tender;
using Backend.Repository.TenderRepository;
using Service;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public void DeleteEntity(Offer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offer> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Offer GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Offer entity)
        {
            throw new NotImplementedException();
        }
    }
}
