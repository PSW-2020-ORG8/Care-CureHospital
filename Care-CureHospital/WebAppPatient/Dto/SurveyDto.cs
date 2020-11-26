using Model.Patient;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public String CommentSurvey { get; set; }
        public DateTime PublishingDate { get; set; }
        public int medicalExaminationID { get; set; }
        public List<Question> Questions { get; set; }
        public SurveyDto() { }
    }
}
