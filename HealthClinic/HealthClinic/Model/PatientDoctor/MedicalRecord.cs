/***********************************************************************
 * Module:  MedicalRecord.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.MedicalRecord
 ***********************************************************************/

using HealthClinic.Repository;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.PatientDoctor
{
    public class MedicalRecord : IIdentifiable<int>
    {
        private int id;
        private Model.AllActors.Patient patient;
        private Anamnesis anamnesis;
        private List<Allergies> allergies;
        private List<Medicament> medicament;

        public AllActors.Patient Patient { get => patient; set => patient = value; }
        public Anamnesis Anamnesis { get => anamnesis; set => anamnesis = value; }
        public List<Allergies> Allergies { get => allergies; set => allergies = value; }
        public List<Medicament> Medicament { get => medicament; set => medicament = value; }

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