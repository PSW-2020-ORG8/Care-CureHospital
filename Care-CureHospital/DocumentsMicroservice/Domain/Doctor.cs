using DocumentsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class Doctor : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Doctor(string name, string surname)
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
