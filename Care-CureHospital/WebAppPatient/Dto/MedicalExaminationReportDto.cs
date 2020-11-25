using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class MedicalExaminationReportDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string PublishingDate { get; set; }
        public string Doctor { get; set; }
        public string Room { get; set; }

        public MedicalExaminationReportDto() { }
    }
}
