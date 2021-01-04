using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Tender
{
    public class Offer : IIdentifiable<int>
    {
        public int Id { get; set; }

        public int MedicamentId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public String Comment { get; set; }

        public Offer()
        {

        }

        public Offer(int id, int medicamentId, double price, int quantity, String comment)
        {
            Id = id;
            MedicamentId = medicamentId;
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
