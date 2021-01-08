using EventSourcingMicroservice.Domain;
using System.Collections.Generic;

namespace EventSourcingMicroservice.Services
{
    public interface IDomainEventService
    {
        DomainEvent Save(DomainEvent domainEvent);
        IEnumerable<DomainEvent> Load(EventType eventType);
    }
}
