using EventSourcingMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Services
{
    public interface ISchedulingAppointmentEventService
    {
        DomainEvent Save(DomainEvent domainEvent);
        IEnumerable<DomainEvent> Load(EventType eventType);
    }
}
