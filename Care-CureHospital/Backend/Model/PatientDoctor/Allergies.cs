// File:    Allergies.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:29:27
// Purpose: Definition of Class Allergies

using HealthClinic.Repository;
using System;

namespace Model.PatientDoctor
{
    public class Allergies : IIdentifiable<int>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        public Allergies(int id)
        {
            this.Id = id;
        }

        public Allergies()
        {
        }

        public Allergies(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        public Allergies(string name)
        {
            this.Name = name;
        }

        public Allergies(int id, string name, int medicalRecordID) : this(id, name)
        {
            this.MedicalRecordId = medicalRecordID;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}