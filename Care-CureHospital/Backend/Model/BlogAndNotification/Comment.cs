/***********************************************************************
 * Module:  Comment.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Blog.Comment
 ***********************************************************************/

using System;
using Model.AllActors;

namespace Model.BlogAndNotification
{
    public class Comment : Content
    {
        public int id { get; set; }
        public int patientID { get; set; }
        public int doctorID { get; set; }
        public virtual AllActors.Patient patient { get; set; }
        public virtual AllActors.Doctor doctor { get; set; }

        public Comment(int id)
        {
            this.id = id;
        }

        public Comment()
        {
        }

        public Comment(int id, AllActors.Patient patient, AllActors.Doctor doctor) : this(id)
        {
            this.patient = patient;
            this.doctor = doctor;
        }

        public Comment(AllActors.Patient patient, AllActors.Doctor doctor)
        {
            this.patient = patient;
            this.doctor = doctor;
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