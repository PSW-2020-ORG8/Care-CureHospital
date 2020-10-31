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
        private int id;
        public AllActors.Patient patient;
        public AllActors.Doctor doctor;

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

        /// <summary>
        /// Property for Model.AllActors.Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Model.AllActors.Doctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                this.doctor = value;
            }
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

    }
}