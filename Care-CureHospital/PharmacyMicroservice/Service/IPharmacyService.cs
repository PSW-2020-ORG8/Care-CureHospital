using PharmacyMicroservice.Domain;

namespace PharmacyMicroservice.Service
{
    public interface IPharmacyService : IService<Pharmacies, int>
    {
        bool DoesNameExist(string name);
        bool DoesKeyExist(string key);
    }
}
