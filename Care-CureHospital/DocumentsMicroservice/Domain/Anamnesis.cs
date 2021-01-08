using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class Anamnesis
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //public virtual List<Diagnosis> Diagnosis { get; set; }
        //public virtual List<Symptoms> Symptoms { get; set; }

        public Anamnesis()
        {
        }

        public Anamnesis(string description)
        {
            Description = description;
        }

        public Anamnesis(int id, string description)
        {
            Description = description;
        }

    }
}
