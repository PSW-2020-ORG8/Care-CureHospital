using DocumentsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class Prescription : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime PublishingDate { get; set; }
        public int MedicalExaminationId { get; set; }
        //public virtual List<Medicament> Medicaments { get; set; }

        public Prescription() { }

        public Prescription(int id, string comment, DateTime publishingDate, int medicalExaminationId)
        {
            Id = id;
            Comment = comment;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationId;
        }

        /*public Prescription(int id, string comment, DateTime publishingDate, int medicalExaminationId, List<Medicament> medicaments)
        {
            Id = id;
            Comment = comment;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationId;
            Medicaments = medicaments;
        }*/

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
