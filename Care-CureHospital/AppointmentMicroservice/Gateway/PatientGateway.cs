using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Gateway.Interface;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace AppointmentMicroservice.Gateway
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

        public Patient SetMaliciousPatient(int patientId)
        {
            Patient patient = null;
            using HttpClient client = new HttpClient();
            var task = client.PutAsync(GetPatientService() + "/api/patient/setMaliciousPatient/" + patientId, null)
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
