using DocumentsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class MedicalRecord : IIdentifiable<int>
    {
        public int Id { get; set; }
        public int AnamnesisId { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }
        public virtual List<Allergies> Allergies { get; set; }
        public virtual List<Medicament> Medicaments { get; set; }
        public bool ActiveMedicalRecord { get; set; }
        public int PatientId { get; set; }
        [NotMapped]
        public virtual Patient Patient { get; set; }

        public MedicalRecord()
        {
        }

        public MedicalRecord(int id, Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(int id, int patientId, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament)
        {
            PatientId = patientId;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(int id, int patientId, Patient patient, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord)
        {
            PatientId = patientId;
            Patient = patient;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public MedicalRecord(int id, int patientId, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord) 
        {
            PatientId = patientId;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
