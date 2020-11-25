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
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public virtual GradeOfQuestion Answer { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        public Question(int id)
        {
            Id = id;
        }

        public Question()
        {
        }


        public Question(int id, string questionText, int surveyID) : this(id)
        {
            QuestionText = questionText;
            SurveyId = surveyID;
        }

        public Question(int id, string questionText, GradeOfQuestion answer, int surveyID, Survey survey) : this(id)
        {
            QuestionText = questionText;
            Answer = answer;
            SurveyId = surveyID;
            Survey = survey;
        }

        public Question(string questionText, GradeOfQuestion answer)
        {
            QuestionText = questionText;
            Answer = answer;
        }

        public Question(string questionText)
        {
            QuestionText = questionText;
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