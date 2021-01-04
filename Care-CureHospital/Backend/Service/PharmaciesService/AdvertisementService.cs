using Backend.Model.Pharmacy;
using Backend.Repository.PharmacyRepository;
using Service;
using System.Collections.Generic;

namespace Backend.Service.PharmaciesService
{
    public class AdvertisementService : IService<Advertisement, int>
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
