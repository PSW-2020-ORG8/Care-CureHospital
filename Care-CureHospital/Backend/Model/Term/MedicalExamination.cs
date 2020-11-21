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
        public int Id { get; set; }
        public bool Urgency { get; set; }
        public String ShortDescription { get; set; }
        public int RoomId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public virtual Room Room { get; set; }
        public virtual AllActors.Doctor Doctor { get; set; }
        public virtual AllActors.Patient Patient { get; set; }

        public MedicalExamination(int id)
        {
            this.Id = id;
        }

        public MedicalExamination()
        {
        }

        public MedicalExamination(int id, bool urgency, string shortDescription, Room room, AllActors.Doctor doctor, AllActors.Patient patient, DateTime fromDateTime, DateTime toDateTime)
            : base(fromDateTime, toDateTime)
        {
            this.Urgency = urgency;
            this.ShortDescription = shortDescription;
            this.Id = id;
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
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}