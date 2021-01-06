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
        public string Name { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public Medicament()
        {
        }

        public Medicament(int id, string name)
        {
            Name = name;
            Id = id;
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
