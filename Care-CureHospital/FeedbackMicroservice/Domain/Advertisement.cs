using FeedbackMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Domain
{
    public class Advertisement : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string PharmacyName { get; set; }
        public double Percent { get; set; }
        public string Period { get; set; }
        public string Manufacturer { get; set; }

        public Advertisement() { }

        public Advertisement(string pharmacyName, double percent, string period, string manifacturer)
        {
            PharmacyName = pharmacyName;
            Percent = percent;
            Period = period;
            Manufacturer = manifacturer;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
