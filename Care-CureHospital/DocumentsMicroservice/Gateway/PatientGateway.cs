using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Gateway.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Gateway
{
    public class PatientGateway : IPatientGateway
    {
        public bool DoesUsernameExist(string username)
        {
            bool doesExist = false;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetPatientService() + "/api/patient/doesUsernameExist/" + username)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    doesExist = JsonConvert.DeserializeObject<bool>(json.Result);
                });
            task.Wait();
            return doesExist;
        }

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

        public Patient AddPateint(Patient patient)
        {
            using HttpClient client = new HttpClient();
            var task = client.PostAsync(GetPatientService() + "/api/patient/addPateint", new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json"))
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

        public Patient GetPatientByUsername(string username)
        {
            Patient patient = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetPatientService() + "/api/patient/getPatientByUsername/" + username)
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
            string origin = Environment.GetEnvironmentVariable("USERS_URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("USERS_PORT") ?? "59947";

            return $"http://{origin}:{port}";
        }
    }
}
