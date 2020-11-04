/***********************************************************************
 * Module:  SurgerySchedule.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.SurgerySchedule
 ***********************************************************************/

using HealthClinic.Repository;
using Model.Doctor;
using Model.AllActors;
using System;

namespace Model.Term
{
    public class Surgery : Term, IIdentifiable<int>
    {
        public int id { get; set; }
        public bool Urgency { get; set; }
        public String ShortDescription { get; set; }
        public int roomID { get; set; }
        public int doctorSpecialistID { get; set; }
        public int patientID { get; set; }
        public virtual Room Room { get; set; }
        public virtual AllActors.Doctor DoctorSpecialist { get; set; }
        public virtual AllActors.Patient Patient { get; set; }

        public Surgery(int id)
        {
            this.id = id;
        }

        public Surgery()
        {
        }

        public Surgery(int id, bool urgency, string shortDescription, Room room, Model.AllActors.Doctor doctorSpecialist, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Urgency = urgency;
            this.ShortDescription = shortDescription;
            this.id = id;
            this.Room = room;
            this.DoctorSpecialist = doctorSpecialist;
            this.Patient = patient;
        }

        public Surgery(bool urgency, string shortDescription, Room room, Model.AllActors.Doctor doctorSpecialist, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Urgency = urgency;
            this.ShortDescription = shortDescription;
            this.Room = room;
            this.DoctorSpecialist = doctorSpecialist;
            this.Patient = patient;
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