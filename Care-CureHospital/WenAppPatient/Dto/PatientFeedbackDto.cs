using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WenAppPatient.Dto
{
    public class PatientFeedbackDto
    {
        public bool isForPublishing { get; set; }
        public bool isPublished { get; set; }
        public bool isAnonymous { get; set; }
        public Patient patient { get; set; }
        public String text { get; set; }
        public DateTime publishingDate { get; set; }

        public PatientFeedbackDto() { }

    }
}
