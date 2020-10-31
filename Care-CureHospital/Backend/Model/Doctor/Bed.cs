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
        private int id;
        private bool taken;       
        private AllActors.Patient patient;

        public bool Taken { get => taken; set => taken = value; }
        public AllActors.Patient Patient { get => patient; set => patient = value; }

        public Bed(int id)
        {
            this.id = id;
        }

        public Bed()
        {
        }

        public Bed(int id, bool taken, AllActors.Patient patient)
        {
            this.Taken = taken;
            this.id = id;
            this.Patient = patient;
        }

        public Bed(bool taken, AllActors.Patient patient)
        {
            this.Taken = taken;
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