using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Domain.SchedulingAppointmentEvents
{
    public class StartSchedulingAppointmentEvent : DomainEvent
    {
        public EventType EventType;
        public String PatientUsername { get; set; }

        public StartSchedulingAppointmentEvent() {}
        public StartSchedulingAppointmentEvent(String patientUsername) : base()
        {
            PatientUsername = patientUsername;
            EventType = EventType.START_SCHEDULING_APPOINTMENT_EVENT;
        }
    }
}
