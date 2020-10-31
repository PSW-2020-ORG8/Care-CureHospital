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
        private bool urgency;
        private String shortDescription;
        private int id;
        private Room room;
        private AllActors.Doctor doctor;
        private Bed bedForLaying;

        public bool Urgency { get => urgency; set => urgency = value; }
        public string ShortDescription { get => shortDescription; set => shortDescription = value; }
        public Room Room { get => room; set => room = value; }
        public AllActors.Doctor Doctor { get => doctor; set => doctor = value; }
        public Bed BedForLaying { get => bedForLaying; set => bedForLaying = value; }

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