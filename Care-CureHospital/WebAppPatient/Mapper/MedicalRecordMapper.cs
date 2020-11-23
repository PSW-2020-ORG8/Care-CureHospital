using Model.AllActors;
using Model.DoctorMenager;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class MedicalRecordMapper
    {
        public static MedicalRecord MedicalRecordDtoToMedicalRecord(MedicalRecordDto dto)
        {
            MedicalRecord medicalRecord = new MedicalRecord(new Patient(), new Anamnesis(), new List<Allergies>(), new List<Medicament>());

            medicalRecord.Id = dto.Id;
            medicalRecord.Patient = dto.Patient;
            medicalRecord.PatientId = medicalRecord.Patient.Id;
            medicalRecord.AnamnesisId = dto.AnamnesisId; 
            medicalRecord.Anamnesis = new Anamnesis();
            medicalRecord.Allergies = dto.Allergies;
            medicalRecord.Medicaments = new List<Medicament>();
            medicalRecord.ActiveMedicalRecord = false;
            
            return medicalRecord;
        }

        public static MedicalRecordDto MedicalRecordToMedicalRecordDto(MedicalRecord medicalRecord)
        {
            MedicalRecordDto dto = new MedicalRecordDto();

            dto.Id = medicalRecord.Id;
            dto.Patient = medicalRecord.Patient;
            medicalRecord.Patient.Id = medicalRecord.PatientId;
            dto.Allergies = medicalRecord.Allergies;
            dto.ActiveMedicalRecord = medicalRecord.ActiveMedicalRecord;

            return dto;
        }
    }
}
