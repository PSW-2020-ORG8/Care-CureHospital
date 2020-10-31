/***********************************************************************
 * Module:  IssueOfMedicaments.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.IssueOfMedicaments
 ***********************************************************************/

using HealthClinic.Repository;
using Model.DoctorMenager;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
    public class IssueOfMedicaments : IIdentifiable<int>
    {
        private int id;
        private String receipt;
        private MedicalRecord medicalRecord;
        private AllActors.Doctor doctor;
        private List<Medicament> medicaments;
 
        public string Receipt { get => receipt; set => receipt = value; }
        public MedicalRecord MedicalRecord { get => medicalRecord; set => medicalRecord = value; }
        public AllActors.Doctor Doctor { get => doctor; set => doctor = value; }
        public List<Medicament> Medicaments { get => medicaments; set => medicaments = value; }

        public IssueOfMedicaments(int id)
        {
            this.id = id;
        }

        public IssueOfMedicaments()
        {
        }

        public IssueOfMedicaments(int id, string receipt, MedicalRecord medicalRecord, AllActors.Doctor doctor, List<Medicament> medicaments)
        {
            this.Receipt = receipt;
            this.id = id;
            this.MedicalRecord = medicalRecord;
            this.Doctor = doctor;
            this.medicaments = medicaments;
        }

        public IssueOfMedicaments(string receipt, MedicalRecord medicalRecord, AllActors.Doctor doctor, List<Medicament> medicaments)
        {
            this.Receipt = receipt;
            this.MedicalRecord = medicalRecord;
            this.Doctor = doctor;
            this.medicaments = medicaments;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }          

    }
}