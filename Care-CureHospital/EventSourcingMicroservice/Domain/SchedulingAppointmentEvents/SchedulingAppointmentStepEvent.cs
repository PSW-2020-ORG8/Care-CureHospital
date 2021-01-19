using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Domain.SchedulingAppointmentEvents
{
    public class SchedulingAppointmentStepEvent : DomainEvent
    {
        public EventType EventType;
        public String PatientUsername { get; set; }
        public int StepNumber { get; set; }
        public StepType StepType { get; set; }

        public SchedulingAppointmentStepEvent() {}

        public SchedulingAppointmentStepEvent(String patientUsername, int stepNumber, StepType stepType) : base()
        {
            PatientUsername = patientUsername;
            StepNumber = stepNumber;
            StepType = stepType;
            EventType = EventType.SCHEDULING_APPOINTMENT_STEP_EVENT;
        }
    }
}
