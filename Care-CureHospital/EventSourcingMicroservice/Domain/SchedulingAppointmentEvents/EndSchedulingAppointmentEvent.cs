﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Domain.SchedulingAppointmentEvents
{
    public class EndSchedulingAppointmentEvent : DomainEvent
    {
        public EventType EventType;
        public String PatientUsername { get; set; }
        public SchedulingResultType SchedulingResultType { get; set; }

        public EndSchedulingAppointmentEvent() {}

        public EndSchedulingAppointmentEvent(String patientUsername, SchedulingResultType schedulingResultType) : base()
        {
            PatientUsername = patientUsername;
            SchedulingResultType = schedulingResultType;
            EventType = EventType.END_SCHEDULING_APPOINTMENT_EVENT;
        }

        public EndSchedulingAppointmentEvent(String patientUsername, SchedulingResultType schedulingResultType, DateTime timeStamp) : base(timeStamp)
        {
            PatientUsername = patientUsername;
            SchedulingResultType = schedulingResultType;
            EventType = EventType.END_SCHEDULING_APPOINTMENT_EVENT;
        }
    }
}
