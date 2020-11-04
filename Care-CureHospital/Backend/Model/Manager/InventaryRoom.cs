using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Manager
{
    public class InventaryRoom : IIdentifiable<int>
    {
        public int id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }

        private InventaryRoom() { }

        public InventaryRoom(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public InventaryRoom(int id, string name, int quantity)
        {
            this.id = id;
            this.Name = name;
            this.Quantity = quantity;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
    }
}
