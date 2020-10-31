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
        private String name;
        private int id;

        public string Name { get => name; set => name = value; }

        public Symptoms(int id)
        {
            this.id = id;
        }

        public Symptoms()
        {
        }

        public Symptoms(int id, string name)
        {
            this.Name = name;
            this.id = id;
        }

        public Symptoms(string name)
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