using Model.AllActors;
using Model.BlogAndNotification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Model.BlogAndNotification
{
    class PatientFeedback : Content
    {
        private int id;
        private bool isForPublishing;
        private bool isPublished;
        private bool isAnonymous;
        private Patient patient;

        public bool IsForPublishing { get => isForPublishing; set => isForPublishing = value; }

        public bool IsPublished { get => isPublished; set => isPublished = value; }

        public bool IsAnonymous { get => isAnonymous; set => isAnonymous = value; }

        public Patient Patient { get => patient; set => patient = value; }

        public int Id { get => id; set => id = value; }

        public PatientFeedback()
        {
        }

        public PatientFeedback(string text, DateTime publishingDate, bool isForPublishing, bool isPublished, bool isAnonymous, Patient patient) : base(text, publishingDate)
        {
            this.isForPublishing = isForPublishing;
            this.isPublished = isPublished;
            this.isAnonymous = isAnonymous;
            this.patient = patient;
        }

       
    }
}
