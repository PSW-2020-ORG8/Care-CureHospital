﻿using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Dto;

namespace DocumentsMicroservice.Mapper
{
    public class AllergiesMapper
    {
        public static Allergies AllergiesDtoToAllergies(AllergiesDto dto)
        {
            Allergies allergy = new Allergies();
            allergy.Id = dto.Id;
            allergy.Name = dto.Name;
            return allergy;
        }

        public static AllergiesDto AllergiesToAllergiesDto(Allergies allergy)
        {
            AllergiesDto dto = new AllergiesDto();
            dto.Id = allergy.Id;
            dto.Name = allergy.Name;
            dto.MedicalRecordId = allergy.MedicalRecordId;
            return dto;
        }
    }
}
