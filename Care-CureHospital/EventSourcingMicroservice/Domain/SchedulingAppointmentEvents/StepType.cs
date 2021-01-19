using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Domain.SchedulingAppointmentEvents
{
    public enum StepType
    {
        FORWARD,
        BACKWARD
    }
}
