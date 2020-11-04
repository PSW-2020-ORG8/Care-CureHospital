/***********************************************************************
 * Module:  Hospitalitation.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.Hospitalitation
 ***********************************************************************/

using HealthClinic.Repository;
using Model.Doctor;
using System;

namespace Model.Term
{
    public class Hospitalitation : Term, IIdentifiable<int>
    {
        public int id { get; set; }
        public bool Urgency { get; set; }
        public String ShortDescription { get; set; }
        public int roomID { get; set; }
        public int doctorID { get; set; }
        public int bedForLayingID { get; set; }
        public virtual Room Room { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }
        public virtual Bed BedForLaying { get; set; }

        public Hospitalitation(int id)
        {
            this.id = id;
        }

        public Hospitalitation()
        {
        }

        public Hospitalitation(int id, bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, Bed bedForLaying, DateTime fromDateTime, DateTime toDateTime) 
            : base(fromDateTime, toDateTime)
        {
            this.Urgency = urgency;
            this.ShortDescription = shortDescription;
            this.id = id;
            this.Room = room;
            this.Doctor = doctor;
            this.BedForLaying = bedForLaying;
        }

        public Hospitalitation(bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, Bed bedForLaying, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Urgency = urgency;
            this.ShortDescription = shortDescription;
            this.Room = room;
            this.Doctor = doctor;
            this.BedForLaying = bedForLaying;
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