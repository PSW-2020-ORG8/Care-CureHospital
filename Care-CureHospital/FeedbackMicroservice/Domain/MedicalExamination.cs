using FeedbackMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Domain
{
    public class MedicalExamination : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public bool SurveyFilled { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }

        public MedicalExamination()
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