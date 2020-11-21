// File:    Symptoms.cs
// Author:  Stefan
// Created: subota, 16. maj 2020. 22:43:51
// Purpose: Definition of Class Symptoms

using HealthClinic.Repository;
using System;

namespace Model.PatientDoctor
{
    public class Symptoms : IIdentifiable<int>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int AnamnesisId { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }

        public Symptoms(int id)
        {
            this.Id = id;
        }

        public Symptoms()
        {
        }

        public Symptoms(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        public Symptoms(string name)
        {
            this.Name = name;
        }

        public Symptoms(int id, string name, int anamnesisID) : this(id, name)
        {
            this.AnamnesisId = anamnesisID;
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