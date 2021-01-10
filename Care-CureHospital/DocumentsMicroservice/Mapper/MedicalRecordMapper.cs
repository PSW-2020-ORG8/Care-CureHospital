using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Dto;
using System.Collections.Generic;

namespace DocumentsMicroservice.Mapper
{
    public class MedicalRecordMapper
    {
        public static MedicalRecord MedicalRecordDtoToMedicalRecord(MedicalRecordDto dto)
        {
            MedicalRecord medicalRecord = new MedicalRecord(new Patient(), new Anamnesis(), new List<Allergies>(), new List<Medicament>());

            medicalRecord.Id = dto.Id;
            medicalRecord.Patient = dto.Patient;
            medicalRecord.AnamnesisId = dto.AnamnesisId;
            medicalRecord.Anamnesis = new Anamnesis();
            medicalRecord.Allergies = dto.Allergies;
            medicalRecord.Medicaments = new List<Medicament>();
            medicalRecord.ActiveMedicalRecord = false;

            return medicalRecord;
        }

        public static MedicalRecordDto MedicalRecordToMedicalRecordDto(MedicalRecord medicalRecord, Patient patient)
        {
            MedicalRecordDto dto = new MedicalRecordDto();
            dto.Id = medicalRecord.Id;
            dto.Patient = patient;
            dto.PatientId = patient.Id;
            dto.ActiveMedicalRecord = medicalRecord.ActiveMedicalRecord;
            dto.Anamnesis = medicalRecord.Anamnesis;
            dto.Allergies = medicalRecord.Allergies;
            dto.Medicaments = medicalRecord.Medicaments;
            dto.DateOfBirthday = patient.DateOfBirth.ToString("dd.MM.yyyy.");
            dto.ProfilePicture = patient.Username + ".png";

            return dto;
        }
    }
}
