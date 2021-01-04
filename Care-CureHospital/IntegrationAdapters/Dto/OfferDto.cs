using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Dto
{
    public class OfferDto
    {
        public int Id { get; set; }

        public int MedicamentId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public String Comment { get; set; }

        public OfferDto() { }
    }
}
