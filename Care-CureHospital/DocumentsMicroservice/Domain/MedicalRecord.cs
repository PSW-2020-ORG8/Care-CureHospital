using DocumentsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class MedicalRecord : IIdentifiable<int>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AnamnesisId { get; set; }
        //public virtual List<Allergies> Allergies { get; set; }
        //public virtual List<Medicament> Medicaments { get; set; }
        public bool ActiveMedicalRecord { get; set; }

        public MedicalRecord()
        {
        }

        /*public MedicalRecord(int id, AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament) : this(id)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(int id, int patientId, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament) : this(id)
        {
            PatientId = patientId;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
        }

        public MedicalRecord(int id, int patientId, AllActors.Patient patient, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord) : this(id)
        {
            PatientId = patientId;
            Patient = patient;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public MedicalRecord(int id, AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord) : this(id)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public MedicalRecord(AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord)
        {
            Patient = patient;
            Anamnesis = anamnesis;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }

        public MedicalRecord(int id, int patientId, int anamnesisId, List<Allergies> allergies, List<Medicament> medicament, bool activeMedicalRecord) : this(id)
        {
            PatientId = patientId;
            AnamnesisId = anamnesisId;
            Allergies = allergies;
            Medicaments = medicament;
            ActiveMedicalRecord = activeMedicalRecord;
        }*/

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
