/***********************************************************************
 * Module:  Question.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Patient.Question
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Patient
{
    public class Question : IIdentifiable<int>
    {
        public int id { get; set; }
        public String QuestionText { get; set; }
        public virtual GradeOfQuestion Answer { get; set; }
        public int surveyID { get; set; }
        public virtual Survey Survey { get; set; }

        public Question(int id)
        {
            this.id = id;
        }

        public Question()
        {
        }


        public Question(int id, string questionText, int surveyID) : this(id)
        {
            QuestionText = questionText;
            this.surveyID = surveyID;
        }

        public Question(int id, string questionText, GradeOfQuestion answer, int surveyID, Survey survey) : this(id)
        {
            QuestionText = questionText;
            Answer = answer;
            this.surveyID = surveyID;
            Survey = survey;
        }

        public Question(string questionText, GradeOfQuestion answer)
        {
            this.QuestionText = questionText;
            this.Answer = answer;
        }

        public Question(string questionText)
        {
            this.QuestionText = questionText;
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