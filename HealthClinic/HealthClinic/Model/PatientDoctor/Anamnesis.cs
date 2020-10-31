// File:    Anamnesis.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:29:29
// Purpose: Definition of Class Anamnesis

using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.PatientDoctor
{
    public class Anamnesis
    {
        private String description;
        private List<Diagnosis> diagnosis;
        private List<Symptoms> symptoms;

        public string Description { get => description; set => description = value; }
        public List<Diagnosis> Diagnosis { get => diagnosis; set => diagnosis = value; }
        public List<Symptoms> Symptoms { get => symptoms; set => symptoms = value; }

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