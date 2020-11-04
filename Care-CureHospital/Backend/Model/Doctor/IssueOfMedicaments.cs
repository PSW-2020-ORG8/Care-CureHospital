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
        public int id;
        public String Receipt { get; set; }
        public int medicalRecordID { get; set; }
        public int doctorID { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }
        public virtual List<Medicament> Medicaments { get; set; }

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
            this.Medicaments = medicaments;
        }

        public IssueOfMedicaments(string receipt, MedicalRecord medicalRecord, AllActors.Doctor doctor, List<Medicament> medicaments)
        {
            this.Receipt = receipt;
            this.MedicalRecord = medicalRecord;
            this.Doctor = doctor;
            this.Medicaments = medicaments;
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