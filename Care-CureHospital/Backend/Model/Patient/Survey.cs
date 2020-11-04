/***********************************************************************
 * Module:  Survey.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Patient.Survey
 ***********************************************************************/

using HealthClinic.Repository;
using System;
using System.Collections.Generic;

namespace Model.Patient
{
    public class Survey : IIdentifiable<int>
    {
        public int id { get; set; }
        public String Title { get; set; }
        public DateTime PublishingDate { get; set; }
        public String CommentSurvey { get; set; }
        public int patientID {get;set;}
        public virtual Model.AllActors.Patient Patient { get; set; }
        public virtual List<Question> Question { get; set; }

        public Survey(int id)
        {
            this.id = id;
        }

        public Survey()
        {
        }

        public Survey(int id, string title, DateTime publishingDate, string commentSurvey, AllActors.Patient patient, List<Question> question)
        {
            this.Title = title;
            this.PublishingDate = publishingDate;
            this.CommentSurvey = commentSurvey;
            this.id = id;
            this.Patient = patient;
            this.Question = question;
        }

        public Survey(string title, DateTime publishingDate, string commentSurvey, AllActors.Patient patient, List<Question> question)
        {
            this.Title = title;
            this.PublishingDate = publishingDate;
            this.CommentSurvey = commentSurvey;
            this.Patient = patient;
            this.Question = question;
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