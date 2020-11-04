/***********************************************************************
 * Module:  MedicalExamination.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.MedicalExamination
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Term
{
    public class MedicalExamination : Term, IIdentifiable<int>
    {
        public int id { get; set; }
        public bool Urgency { get; set; }
        public String ShortDescription { get; set; }
        public int roomID { get; set; }
        public int doctorID { get; set; }
        public int patientID { get; set; }
        public virtual Room Room { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }
        public virtual AllActors.Patient Patient { get; set; }

        public MedicalExamination(int id)
        {
            this.id = id;
        }

        public MedicalExamination()
        {
        }

        public MedicalExamination(int id, bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Urgency = urgency;
            this.ShortDescription = shortDescription;
            this.id = id;
            this.Room = room;
            this.Doctor = doctor;
            Patient = patient;
        }

        public MedicalExamination(bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Urgency = urgency;
            this.ShortDescription = shortDescription;
            this.Room = room;
            this.Doctor = doctor;
            Patient = patient;

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