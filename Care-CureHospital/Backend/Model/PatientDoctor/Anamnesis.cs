// File:    Anamnesis.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:29:29
// Purpose: Definition of Class Anamnesis

using System;
using System.Collections.Generic;


namespace Model.PatientDoctor
{
    public class Anamnesis
    {
        public int id { get; set; }

        public String Description { get; set; }
        public virtual List<Diagnosis> Diagnosis { get; set; }
        public virtual List<Symptoms> Symptoms { get; set; }

        public Anamnesis()
        {
        }

        public Anamnesis(string description, List<Diagnosis> diagnosis, List<Symptoms> symptoms)
        {
            this.Description = description;
            this.Diagnosis = diagnosis;
            this.Symptoms = symptoms;
        }

        public Anamnesis(int id, string description, List<Diagnosis> diagnosis, List<Symptoms> symptoms)
        {
            this.Description = description;
            this.Diagnosis = diagnosis;
            this.Symptoms = symptoms;
        }

        public Anamnesis(string description)
        {
            this.Description = description;
            
        }
    }
}