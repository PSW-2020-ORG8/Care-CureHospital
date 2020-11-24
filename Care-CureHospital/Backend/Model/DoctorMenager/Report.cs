using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.DoctorMenager
{
    public class Report : IIdentifiable<int>
    {
        public int Id { get; set; }
        
        public String MedicationName { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set;  }

        public Report(int id, string name, int quantity)
        {
            this.Id = id;

            this.MedicationName = name;

            this.Quantity = quantity;


        }

        public Report(string name, int quantity)
        {

            this.MedicationName = name;

            this.Quantity = quantity;
            

        }


        public Report(String name)
        {
            this.MedicationName = name;
        }
        public Report()
        {

        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }

    }
}
