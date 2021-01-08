using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Dto
{
    public class OfferDto
    {
        public int Id { get; set; }

        public int TenderId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Comment { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyEmail { get;  set; }

        public OfferDto() { }
    }
}
