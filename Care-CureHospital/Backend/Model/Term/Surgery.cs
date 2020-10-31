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
        private bool urgency;
        private String shortDescription;
        private int id;
        private Room room;
        private AllActors.Doctor doctorSpecialist;
        public AllActors.Patient patient;

        public bool Urgency { get => urgency; set => urgency = value; }
        public string ShortDescription { get => shortDescription; set => shortDescription = value; }
        public Room Room { get => room; set => room = value; }
        public Model.AllActors.Doctor DoctorSpecialist { get => doctorSpecialist; set => doctorSpecialist = value; }

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
            this.patient = patient;
        }

        public Surgery(bool urgency, string shortDescription, Room room, Model.AllActors.Doctor doctorSpecialist, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Urgency = urgency;
            this.ShortDescription = shortDescription;
            this.Room = room;
            this.DoctorSpecialist = doctorSpecialist;
            this.patient = patient;
        }

        /// <summary>
        /// Property for Model.AllActors.Patient
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Model.AllActors.Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                this.patient = value;
            }
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