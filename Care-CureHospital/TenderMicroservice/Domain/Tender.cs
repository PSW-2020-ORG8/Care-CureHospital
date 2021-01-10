using System;
using TenderMicroservice.Repository;

namespace TenderMicroservice.Domain
{
    public class Tender : IIdentifiable<int>
    {
        public int Id { get; set; }

        public String MedicamentName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

        public bool ChoosenOffer { get; set; }

        public Tender()
        {
        }

        public Tender(int id, String medicamentName, DateTime startDate, DateTime endDate, bool active, bool choosenOffer)
        {
            Id = id;
            MedicamentName = medicamentName;
            StartDate = startDate;
            EndDate = endDate;
            Active = active;
            ChoosenOffer = choosenOffer;
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
