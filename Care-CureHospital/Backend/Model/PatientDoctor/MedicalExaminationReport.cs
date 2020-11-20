using HealthClinic.Repository;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientDoctor
{
    public class MedicalExaminationReport : IIdentifiable<int>
    {
        public int id { get; set; }
        public String Comment { get; set; }
        public DateTime PublishingDate { get; set; }
        public int medicalExaminationID { get; set; }
        public virtual MedicalExamination MedicalExamination { get; set; }

        public MedicalExaminationReport() { }

        public MedicalExaminationReport(int id, string comment, DateTime publishingDate, int medicalExaminationID, MedicalExamination medicalExamination)
        {
            this.id = id;
            Comment = comment;
            PublishingDate = publishingDate;
            this.medicalExaminationID = medicalExaminationID;
            MedicalExamination = medicalExamination;
        }

        public MedicalExaminationReport(string comment, DateTime publishingDate, int medicalExaminationID, MedicalExamination medicalExamination)
        {
            Comment = comment;
            PublishingDate = publishingDate;
            this.medicalExaminationID = medicalExaminationID;
            MedicalExamination = medicalExamination;
        }

        public MedicalExaminationReport(int id, string comment, DateTime publishingDate, int medicalExaminationID)
        {
            this.id = id;
            Comment = comment;
            PublishingDate = publishingDate;
            this.medicalExaminationID = medicalExaminationID;
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
