using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Repository;
using System.Collections.Generic;

namespace EventSourcingMicroservice.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly IRepository _repository;
        public DomainEventService(IRepository repository) 
        {
            _repository = repository;
        }
        public IEnumerable<DomainEvent> Load(EventType eventType)
        {
            return _repository.Load(eventType);
        }
        public DomainEvent Save(DomainEvent domainEvent)
        {
            return _repository.Save(domainEvent);
        }
    }
}
