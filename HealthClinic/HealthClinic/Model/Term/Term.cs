/***********************************************************************
 * Module:  Termin.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.Termin
 ***********************************************************************/

using System;

namespace Model.Term
{
    public abstract class Term
    {
        private DateTime fromDateTime;
        private DateTime toDateTime;

        public DateTime FromDateTime { get => fromDateTime; set => fromDateTime = value; }
        public DateTime ToDateTime { get => toDateTime; set => toDateTime = value; }

        public Term(DateTime fromDateTime, DateTime toDateTime)
        {
            FromDateTime = fromDateTime;
            ToDateTime = toDateTime;
        }

        public Term()
        {
            
        }
    }
}