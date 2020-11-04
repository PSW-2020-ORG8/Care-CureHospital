/***********************************************************************
 * Module:  MedicalRecord.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.MedicalRecord
 ***********************************************************************/

using HealthClinic.Repository;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;


namespace Model.PatientDoctor
{
    public class MedicalRecord : IIdentifiable<int>
    {
        public int id { get; set; }
        public int patientID { get; set; }
        public virtual AllActors.Patient Patient { get; set; }
        public int anamnesisID { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }
        public virtual List<Allergies> Allergies { get; set; }
        public virtual List<Medicament> Medicament { get; set; }


        public MedicalRecord(int id)
        {
            this.id = id;
        }

        public MedicalRecord()
        {
        }

        public MedicalRecord(int id, AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament) : this(id)
        {
            this.Patient = patient;
            this.Anamnesis = anamnesis;
            this.Allergies = allergies;
            this.Medicament = medicament;
        }

        public MedicalRecord(AllActors.Patient patient, Anamnesis anamnesis, List<Allergies> allergies, List<Medicament> medicament)
        {
            this.Patient = patient;
            this.Anamnesis = anamnesis;
            this.Allergies = allergies;
            this.Medicament = medicament;
        }

        public void Review()
        {
            throw new NotImplementedException();
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