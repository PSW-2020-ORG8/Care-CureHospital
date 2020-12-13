using Backend.Model.PatientDoctor;
using IntegrationAdapters.Dto;
using Model.AllActors;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Mapper
{
    public class EPrescriptionMapper 
    {
        public static EPrescriptionDto EPrescriptionToEPresctriptionDto(EPrescription ePrescription)
        {
            EPrescriptionDto dto = new EPrescriptionDto();
            dto.Id = ePrescription.Id;
            dto.PatientId = ePrescription.PatientId;
            dto.PatientName = ePrescription.PatientName;
            dto.Comment = ePrescription.Comment;
            dto.MedicamentName = ePrescription.MedicamentName;
            dto.PublishingDate = ePrescription.PublishingDate;
            return dto;
        }

        public static EPrescription EPrescriptionDtoToEPrescription(EPrescriptionDto dto, EPrescription eprescription)
        {
            EPrescription newEPrescriptions = new EPrescription();
            newEPrescriptions.Id = dto.Id;
            newEPrescriptions.PatientId = dto.PatientId;
            newEPrescriptions.PatientName = dto.PatientName;
            newEPrescriptions.MedicamentName = dto.MedicamentName;
            newEPrescriptions.PublishingDate = dto.PublishingDate;
            return newEPrescriptions;
        }
    }
}
