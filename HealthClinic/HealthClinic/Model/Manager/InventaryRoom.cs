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
        private int id;
        private String name;
        private int quantity;

        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        private InventaryRoom() { }

        public InventaryRoom(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }

        public InventaryRoom(int id, string name, int quantity)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
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
