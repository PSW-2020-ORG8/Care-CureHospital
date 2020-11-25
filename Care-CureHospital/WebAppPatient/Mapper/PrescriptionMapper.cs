using Backend.Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class PrescriptionMapper
    {
        public static PrescriptionDto PrescriptionToPrescriptionDto(Prescription prescription)
        {
            PrescriptionDto dto = new PrescriptionDto();
            dto.Id = prescription.Id;
            dto.Comment = prescription.Comment;
            dto.PublishingDate = prescription.PublishingDate.ToString("dd.MM.yyyy. HH:mm");
            dto.Doctor = prescription.MedicalExamination.Doctor.Name + " " + prescription.MedicalExamination.Doctor.Surname;
            List<string> medicaments = new List<string>();
            prescription.Medicaments.ToList().ForEach(medicament => medicaments.Add(medicament.Name));
            dto.Medicaments = medicaments;
            return dto;
        }
    }
}
