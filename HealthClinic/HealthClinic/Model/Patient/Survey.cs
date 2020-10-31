/***********************************************************************
 * Module:  Survey.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Patient.Survey
 ***********************************************************************/

using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.Patient
{
    public class Survey : IIdentifiable<int>
    {
        private int id;
        private String title;
        private DateTime publishingDate;
        private String commentSurvey;
        private Model.AllActors.Patient patient;
        private List<Question> question;

        public string Title { get => title; set => title = value; }
        public DateTime PublishingDate { get => publishingDate; set => publishingDate = value; }
        public string CommentSurvey { get => commentSurvey; set => commentSurvey = value; }
        public AllActors.Patient Patient { get => patient; set => patient = value; }
        public List<Question> Question { get => question; set => question = value; }

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