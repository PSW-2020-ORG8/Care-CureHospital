using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Domain
{
    public enum EventType
    {
        LOGIN_EVENT,
        URL_EVENT,
        START_SCHEDULING_APPOINTMENT_EVENT,
        END_SCHEDULING_APPOINTMENT_EVENT,
        SCHEDULING_APPOINTMENT_STEP_EVENT
    }
}
