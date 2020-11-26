using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class QuestionResultDto
    {

        public int QuestionId { get; set; }

        public List<int> Grades { get; set; }

        public double AverageGrade { get; set; }

        public QuestionResultDto() { }
    }
}
