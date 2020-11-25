using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatient.Dto
{
    public class QuestionResultDto
    {

        public String QuestionText { get; set; }

        public List<int> Grades { get; set; }

        public double AverageGrade { get; set; }

        public QuestionResultDto() { }
    }
}
