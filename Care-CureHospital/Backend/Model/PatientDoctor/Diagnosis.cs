// File:    Diagnosis.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:29:28
// Purpose: Definition of Class Diagnosis

using HealthClinic.Repository;
using System;

namespace Model.PatientDoctor
{
    public class Diagnosis : IIdentifiable<int>
    {
        public int id { get; set; }
        public String Name { get; set; }

        public Diagnosis(int id)
        {
            this.id = id;
        }

        public Diagnosis()
        {
        }

        public Diagnosis(int id, string name)
        {
            this.Name = name;
            this.id = id;
        }

        public Diagnosis(string name)
        {
            this.Name = name;
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