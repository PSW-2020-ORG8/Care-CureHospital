using PharmacyMicroservice.Domain;
using PharmacyMicroservice.Repository;
using System.Collections.Generic;

namespace PharmacyMicroservice.Service
{
    public class PharmacyService : IPharmacyService
    {
        public IPharmacyRepository pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public Pharmacies GetEntity(int id)
        {
            return pharmacyRepository.GetEntity(id);
        }

        public IEnumerable<Pharmacies> GetAllNames()
        {
            return pharmacyRepository.GetAllNames();
        }

        public IEnumerable<Pharmacies> GetAllEntities()
        {
            return pharmacyRepository.GetAllEntities();
        }

        public Pharmacies AddEntity(Pharmacies entity)
        {
            return pharmacyRepository.AddEntity(entity);
        }

        public void UpdateEntity(Pharmacies entity)
        {
            pharmacyRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Pharmacies entity)
        {
            pharmacyRepository.DeleteEntity(entity);
        }

        public bool DoesNameExist(string name)
        {
            foreach (Pharmacies pharmacy in GetAllEntities())
                if (pharmacy.Name.Equals(name))
                    return true;
            return false;
        }

        public bool DoesKeyExist(string key)
        {
            foreach (Pharmacies pharmacy in GetAllEntities())
                if (pharmacy.Key.Equals(key))
                    return true;
            return false;
        }
    }
}
