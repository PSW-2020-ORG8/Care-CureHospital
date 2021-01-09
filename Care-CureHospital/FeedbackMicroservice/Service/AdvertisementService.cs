using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        IAdvertisementRepository advertisementRepository;

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            this.advertisementRepository = advertisementRepository;
        }

        public Advertisement AddEntity(Advertisement entity)
        {
            return advertisementRepository.AddEntity(entity);
        }

        public void DeleteEntity(Advertisement entity)
        {
            advertisementRepository.DeleteEntity(entity);
        }

        public IEnumerable<Advertisement> GetAllEntities()
        {
            return advertisementRepository.GetAllEntities();
        }

        public Advertisement GetEntity(int id)
        {
            return advertisementRepository.GetEntity(id);
        }

        public void UpdateEntity(Advertisement entity)
        {
            advertisementRepository.UpdateEntity(entity);
        }
    }
}
