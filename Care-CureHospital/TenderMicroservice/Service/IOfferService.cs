using System.Collections.Generic;
using TenderMicroservice.Domain;

namespace TenderMicroservice.Service
{
    public interface IOfferService : IService<Offer, int>
    {
        public List<Offer> GetAllOffersForActiveTender();
        public List<Offer> GetAllOffersForInactiveTender();
        Offer ChooseOffer(int id);
    }
}