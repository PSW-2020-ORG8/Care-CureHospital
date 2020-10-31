/***********************************************************************
 * Module:  FeedbackOfValidation.cs
 * Author:  Stefan
 * Purpose: Definition of the Class DoctorMenager.FeedbackOfValidation
 ***********************************************************************/

using System;

namespace Model.DoctorMenager
{
    public class FeedbackOfValidation
    {
        private String comment;
        public string Comment { get => comment; set => comment = value; }
        public FeedbackOfValidation()
        {
        }

        public FeedbackOfValidation(string comment)
        {
            this.Comment = comment;
        }

       
    }
}