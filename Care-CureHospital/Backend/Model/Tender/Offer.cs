﻿using HealthClinic.Repository;
using System;

namespace Backend.Model.Tender
{
    public class Offer : IIdentifiable<int>
    {
        public int Id { get; set; }

        public int MedicamentId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public String Comment { get; set; }

        public bool ActiveTender { get; set; }

        public Offer()
        {

        }

        public Offer(int id, int medicamentId, double price, int quantity, String comment, bool activeTender)
        {
            Id = id;
            MedicamentId = medicamentId;
            Price = price;
            Quantity = quantity;
            Comment = comment;
            ActiveTender = activeTender;
        }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
