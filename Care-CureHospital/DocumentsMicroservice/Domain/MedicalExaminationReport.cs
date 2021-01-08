using DocumentsMicroservice.Repository;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentsMicroservice.Domain
{
    public class MedicalExaminationReport : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime PublishingDate { get; set; }
        public int MedicalExaminationId { get; set; }
        [NotMapped]
        public MedicalExamination MedicalExamination { get; set; }

        public MedicalExaminationReport() { }

        public MedicalExaminationReport(int id, string comment, DateTime publishingDate, int medicalExaminationID)
        {
            Id = id;
            Comment = comment;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
        }

        public MedicalExaminationReport(string comment, DateTime publishingDate, int medicalExaminationID, MedicalExamination medicalExamination)
        {
            Comment = comment;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
            MedicalExamination = medicalExamination;
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
