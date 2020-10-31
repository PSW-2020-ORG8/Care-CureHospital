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
        private bool urgency;
        private String shortDescription;
        private int id;
        private Room room;
        private AllActors.Doctor doctor;
        public AllActors.Patient Patient { get; set; }

        public bool Urgency { get => urgency; set => urgency = value; }
        public string ShortDescription { get => shortDescription; set => shortDescription = value; }
        public Room Room { get => room; set => room = value; }
        public AllActors.Doctor Doctor { get => doctor; set => doctor = value; }

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