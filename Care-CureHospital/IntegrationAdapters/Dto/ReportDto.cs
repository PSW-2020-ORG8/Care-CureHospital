using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.DoctorMenager;

namespace IntegrationAdapters.Dto
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }

        public ReportDto() { }
    }
}
