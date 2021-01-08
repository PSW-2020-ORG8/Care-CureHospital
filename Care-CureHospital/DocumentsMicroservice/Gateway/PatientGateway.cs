using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Gateway.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public string GetPatientService()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "59947";

            return $"http://{origin}:{port}";
        }
    }
}
