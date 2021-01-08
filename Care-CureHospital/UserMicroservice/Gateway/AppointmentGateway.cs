using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserMicroservice.Interface.Gateway;

namespace UserMicroservice.Gateway
{
    public class AppointmentGateway : IAppointmentGateway
    {
        public int CountCancelledAppointmentsForPatient(int patientId)
        {
            int numberOfCancelations = 0;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetDoctorService() + "/api/appointment/countCancelledAppointmentsForPatient/" + patientId)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    numberOfCancelations = JsonConvert.DeserializeObject<int>(json.Result);
                });
            task.Wait();
            return numberOfCancelations;
        }

        public string GetDoctorService()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "5171";

            return $"http://{origin}:{port}";
        }
    }
}
