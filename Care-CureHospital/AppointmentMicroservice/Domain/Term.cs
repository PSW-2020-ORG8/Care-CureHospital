using System;

namespace AppointmentMicroservice.Domain
{
    public abstract class Term
    {
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }

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
