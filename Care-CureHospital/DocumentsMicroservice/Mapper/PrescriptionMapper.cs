using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DocumentsMicroservice.Mapper
{
    public class PrescriptionMapper
    {
        public static PrescriptionDto PrescriptionToPrescriptionDto(Prescription prescription, MedicalExamination medicalExamination)
        {
            PrescriptionDto dto = new PrescriptionDto();
            dto.Id = prescription.Id;
            dto.Comment = prescription.Comment;
            dto.PublishingDate = prescription.PublishingDate.ToString("dd.MM.yyyy.");
            dto.Doctor = medicalExamination.Doctor.Name + " " + medicalExamination.Doctor.Surname;
            List<Medicament> medicaments = new List<Medicament>();
            prescription.Medicaments.ToList().ForEach(medicament => medicaments.Add(medicament));
            dto.Medicaments = medicaments;
            return dto;
        }
    }
}