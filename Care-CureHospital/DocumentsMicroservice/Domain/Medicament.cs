using DocumentsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class Medicament : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int Quantity { get; set; }
        public string Ingredients { get; set; }
        public int MedicalRecordId { get; set; }
        public int PrescriptionId { get; set; }

        //public State StateOfValidation { get; set; }


        public Medicament(int id, string code, string name, string producer, int quantity, string ingredients)
        {
            Code = code;
            Name = name;
            Producer = producer;
            Quantity = quantity;
            Id = id;
            Ingredients = ingredients;
        }

        public Medicament(string code, string name, string producer, int quantity, string ingredients)
        {
            Code = code;
            Name = name;
            Producer = producer;
            Quantity = quantity;
            Ingredients = ingredients;
        }

        public Medicament(string name)
        {
            Name = name;
        }

        public Medicament()
        {
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }


    }
}
