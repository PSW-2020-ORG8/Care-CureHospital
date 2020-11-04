using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dto
{
    public class PatientFeedbackDto
    {
        public string Text { get; set; }
        public bool IsForPublishing { get; set; }

        public bool IsPublished { get; set; }

        public bool IsAnonymous { get; set; }
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public DateTime PublishingDate { get; set; }

        public PatientFeedbackDto() { }
    }
}
