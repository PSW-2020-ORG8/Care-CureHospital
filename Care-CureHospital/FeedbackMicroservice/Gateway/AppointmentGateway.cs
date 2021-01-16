using FeedbackMicroservice.Gateway.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Gateway
{
    public class AppointmentGateway : IAppointmentGateway
    {
        public void FilledSurveyForAppointment(int appointmentId)
        {
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetDoctorService() + "/api/appointment/filledSurveyForAppointment/" + appointmentId)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                });
            task.Wait();
        }

        public string GetDoctorService()
        {
            string origin = Environment.GetEnvironmentVariable("APPO_URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("APPO_PORT") ?? "5171";

            return $"http://{origin}:{port}";
        }
    }
}
