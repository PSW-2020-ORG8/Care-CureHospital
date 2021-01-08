using PharmacyMicroservice.Dto;
using PharmacyMicroservice.Service;

namespace PharmacyMicroservice.Validation
{
    public class PharmacyValidation
    {
        private IPharmacyService pharmacyService;

        public PharmacyValidation()
        {

        }

        public bool ValidatePharmacy(PharmaciesDto dto)
        {
            if (!ValidateName(dto.Name) || !ValidateKey(dto.Key))
            {
                return false;
            }
            return true;
        }

        private bool ValidateName(string name)
        {
            if (this.pharmacyService.DoesNameExist(name))
            {
                return false;
            }

            return true;
        }

        private bool ValidateKey(string key)
        {
            if (this.pharmacyService.DoesKeyExist(key))
            {
                return false;
            }
            return true;
        }
    }
}
