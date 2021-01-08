using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Interface.Gateway
{
    public interface IAppointmentGateway
    {
        public int CountCancelledAppointmentsForPatient(int patientId);
    }
}
