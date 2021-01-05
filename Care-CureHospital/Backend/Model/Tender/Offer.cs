﻿using HealthClinic.Repository;
using System;

namespace Backend.Model.Tender
{
    public class Offer : IIdentifiable<int>
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public String Comment { get; set; }

        public Offer()
        {

        }

        public Offer(int id, double price, int quantity, String comment)
        {
            Id = id;
            Price = price;
            Quantity = quantity;
            Comment = comment;
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
