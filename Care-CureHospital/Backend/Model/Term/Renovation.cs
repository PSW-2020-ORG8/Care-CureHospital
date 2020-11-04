/***********************************************************************
 * Module:  Renovation.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Manager.Renovation
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Term
{
    public class Renovation : Term, IIdentifiable<int>
    {
        public int id { get; set; }
        public String DescriptionOfRenovation { get; set; }
        public int roomID { get; set; }
        public virtual Room Room { get; set; }

        public Renovation(int id)
        {
            this.id = id;
        }

        public Renovation()
        {
        }

        public Renovation(int id, string descriptionOfRenovation, Room room, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.id = id;
            this.DescriptionOfRenovation = descriptionOfRenovation;           
            this.Room = room;
        }

        public Renovation(string descriptionOfRenovation,  Room room, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.DescriptionOfRenovation = descriptionOfRenovation;
            this.Room = room;
            this.FromDateTime = fromDateTime;
            this.ToDateTime = toDateTime;
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