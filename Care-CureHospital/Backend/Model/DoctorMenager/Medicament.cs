/***********************************************************************
 * Module:  Medicament.cs
 * Author:  Stefan
 * Purpose: Definition of the Class OtherClasses.Medicament
 ***********************************************************************/

using HealthClinic.Repository;
using System;
using System.Collections.Generic;


namespace Model.DoctorMenager
{
    public class Medicament : IIdentifiable<int>
    {
        public int id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Producer { get; set; }
        public State StateOfValidation { get; set; }
        public int Quantity { get; set; }
        public String Ingredients { get; set; }

        /*public Medicament(int id)
        {
            this.id = id;
        }*/

        public Medicament(int id, string code, string name, string producer, State stateOfValidation, int quantity, string ingredients)
        {
            this.Code = code;
            this.Name = name;
            this.Producer = producer;
            this.StateOfValidation = stateOfValidation;
            this.Quantity = quantity;
            this.id = id;
            this.Ingredients = ingredients;
        }

        public Medicament(string code, string name, string producer, State stateOfValidation, int quantity, string ingredients)
        {
            this.Code = code;
            this.Name = name;
            this.Producer = producer;
            this.StateOfValidation = stateOfValidation;
            this.Quantity = quantity;
            this.Ingredients = ingredients;
        }

        public Medicament(String name)
        {
            this.Name = name;
        }

        public Medicament()
        {
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