using System;
using TenderMicroservice.Repository;

namespace TenderMicroservice.Domain
{
    public class Offer : IIdentifiable<int>
    {
        public int Id { get; set; }

        public int TenderId { get; set; }

        public String PharmacyName { get; set; }

        public String PharmacyEmail { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public String Comment { get; set; }

        public bool ActiveTender { get; set; }

        public Offer()
        {
        }

        public Offer(int id, int tenderId, string pharmacyName, string pharmacyEmail, double price, int quantity, string comment, bool activeTender)
        {
            Id = id;
            TenderId = tenderId;
            PharmacyName = pharmacyName;
            PharmacyEmail = pharmacyEmail;
            Price = price;
            Quantity = quantity;
            Comment = comment;
            ActiveTender = activeTender;
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
