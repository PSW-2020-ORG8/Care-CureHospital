using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class AllergiesMapper
    {
        public static Allergies AllergiesDtoToAllergies(AllergiesDto dto)
        {
            Allergies allergy = new Allergies();
            allergy.Id = dto.Id;
            allergy.Name = dto.Name;
            allergy.MedicalRecordId = dto.MedicalRecordId;
            allergy.MedicalRecord = null;
            return allergy;
        }

        public static AllergiesDto AllergiesToAllergiesDto(Allergies allergy)
        {
            AllergiesDto dto = new AllergiesDto();
            dto.Id = allergy.Id;
            dto.Name = allergy.Name;
            dto.MedicalRecordId = allergy.MedicalRecordId;
            dto.MedicalRecord = null;
            return dto;
        }
    }
}
