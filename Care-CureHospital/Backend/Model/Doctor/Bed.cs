/***********************************************************************
 * Module:  Krevet.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.Krevet
 ***********************************************************************/

using System;
using Model.AllActors;

namespace Model.Doctor
{
    public class Bed
    {
        public int Id { get; set; }
        public bool Taken { get; set; }
        public int PatientId { get; set; }
        public virtual AllActors.Patient Patient { get; set; }


        public Bed(int id)
        {
            this.Id = id;
        }

        public Bed()
        {
        }

        public Bed(int id, bool taken, AllActors.Patient patient)
        {
            this.Taken = taken;
            this.Id = id;
            this.Patient = patient;
        }

        public Bed(bool taken, AllActors.Patient patient)
        {
            this.Taken = taken;
            this.Patient = patient;
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