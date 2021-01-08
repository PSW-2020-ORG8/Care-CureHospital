using FeedbackMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Domain
{
    public class Patient : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Patient()
        {
        }

        public Patient(string name, string surname)
        {
            Name = name;
            Surname = surname;
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
