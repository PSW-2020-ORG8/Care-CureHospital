using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Domain
{
    public class DomainEvent
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public DomainEvent()
        {
            Id = new Guid();
            TimeStamp =  DateTime.UtcNow;
        }

        public DomainEvent(DateTime timeStamp)
        {
            Id = new Guid();
            TimeStamp = timeStamp;
        }

    }
}
