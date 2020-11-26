using Model.DoctorMenager;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string PublishingDate { get; set; }
        public string Doctor { get; set; }
        public List<string> Medicaments { get; set; }

        public PrescriptionDto() { }
    }
}
