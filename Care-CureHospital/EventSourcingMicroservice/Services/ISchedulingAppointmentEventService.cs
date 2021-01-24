using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Domain.SchedulingAppointmentEvents;
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
        public double GetSuccessfulSchedulingPercentage();
        public double GetAverageSchedulingTime(SchedulingResultType schedulingResultType);
        public Dictionary<int, double> GetAverageTimeSpentPerStep();
        public int GetMostOftenQuitingStep();
    }
}
