using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Gateway.Interface
{
    public interface IAppointmentGateway
    {
        public void FilledSurveyForAppointment(int appointmentId);
    }
}
