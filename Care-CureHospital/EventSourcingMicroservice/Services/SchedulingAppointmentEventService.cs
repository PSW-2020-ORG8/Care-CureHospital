using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Services
{
    public class SchedulingAppointmentEventService : ISchedulingAppointmentEventService
    {
        private readonly IRepository _repository;
        public SchedulingAppointmentEventService(IRepository repository)
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
