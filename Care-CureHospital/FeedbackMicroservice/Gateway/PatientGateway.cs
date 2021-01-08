using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Gateway.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Gateway
{
    public class PatientGateway : IPatientGateway
    {
        public Patient GetPatientById(int patientId)
        {
            Patient patient = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetPatientService() + "/api/patient/getPatient/" + patientId)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    patient = JsonConvert.DeserializeObject<Patient>(json.Result);
                });
            task.Wait();
            return patient;
        }

        public string GetPatientService()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "59947";

            return $"http://{origin}:{port}";
        }
    }
}
