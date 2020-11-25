/***********************************************************************
 * Module:  Survey.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Patient.Survey
 ***********************************************************************/

using HealthClinic.Repository;
using Model.Term;
using System;
using System.Collections.Generic;

namespace Model.Patient
{
    public class Survey : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CommentSurvey { get; set; }
        public DateTime PublishingDate { get; set; }
        public int MedicalExaminationId { get; set; }
        public virtual MedicalExamination MedicalExamination { get; set; }
        public virtual List<Question> Questions { get; set; }

        public Survey(int id)
        {
            Id = id;
        }

        public Survey()
        {
        }

        public Survey(int id, string title, DateTime publishingDate, string commentSurvey, List<Question> questions)
        {
            Id = id;
            Title = title;
            PublishingDate = publishingDate;
            CommentSurvey = commentSurvey;
            Questions = questions;
        }

        public Survey(string title, DateTime publishingDate, string commentSurvey, List<Question> questions)
        {
            Title = title;
            PublishingDate = publishingDate;
            CommentSurvey = commentSurvey;
            Questions = questions;
        }

        public Survey(int id, string title, string commentSurvey, DateTime publishingDate, int medicalExaminationID, MedicalExamination medicalExamination, List<Question> questions) : this(id)
        {
            Title = title;
            CommentSurvey = commentSurvey;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
            MedicalExamination = medicalExamination;
            Questions = questions;
        }

        public Survey(int id, string title, string commentSurvey, DateTime publishingDate, int medicalExaminationID, List<Question> questions) : this(id)
        {
            Title = title;
            CommentSurvey = commentSurvey;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
            Questions = questions;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}