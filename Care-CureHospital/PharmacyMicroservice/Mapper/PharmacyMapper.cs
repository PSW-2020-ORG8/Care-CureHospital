using PharmacyMicroservice.Domain;
using PharmacyMicroservice.Dto;

namespace PharmacyMicroservice.Mapper
{
    public class PharmacyMapper
    {
        public static Pharmacies PharmacyDtoToPharmacy(PharmaciesDto dto)
        {
            Pharmacies pharmacy = new Pharmacies();
            pharmacy.Id = dto.Id;
            pharmacy.Name = dto.Name;
            pharmacy.Key = dto.Key;
            pharmacy.Link = dto.Link;
            return pharmacy;
        }

        public static PharmaciesDto PharmacyToPharmacyDto(Pharmacies pharmacy)
        {
            PharmaciesDto dto = new PharmaciesDto();
            dto.Id = pharmacy.Id;
            dto.Name = pharmacy.Name;
            dto.Key = pharmacy.Key;
            dto.Link = pharmacy.Link;
            return dto;
        }
    }
}
