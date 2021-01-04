using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Dto
{
    public class TenderDto
    {
        public int Id { get; set; }

        public string MedicamentName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool Active { get; set; }

        public TenderDto() { }
    }
}
