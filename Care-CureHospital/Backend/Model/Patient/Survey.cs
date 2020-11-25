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
        public virtual List<Question> Question { get; set; }

        public Survey(int id)
        {
            Id = id;
        }

        public Survey()
        {
        }

        public Survey(int id, string title, DateTime publishingDate, string commentSurvey, List<Question> question)
        {
            Title = title;
            PublishingDate = publishingDate;
            CommentSurvey = commentSurvey;
            Id = id;
            Question = question;
        }

        public Survey(string title, DateTime publishingDate, string commentSurvey, List<Question> question)
        {
            Title = title;
            PublishingDate = publishingDate;
            CommentSurvey = commentSurvey;
            Question = question;
        }

        public Survey(int id, string title, string commentSurvey, DateTime publishingDate, int medicalExaminationID, MedicalExamination medicalExamination, List<Question> question) : this(id)
        {
            Title = title;
            CommentSurvey = commentSurvey;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
            MedicalExamination = medicalExamination;
            Question = question;
        }

        public Survey(int id, string title, string commentSurvey, DateTime publishingDate, int medicalExaminationID, List<Question> question) : this(id)
        {
            Title = title;
            CommentSurvey = commentSurvey;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
            Question = question;
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