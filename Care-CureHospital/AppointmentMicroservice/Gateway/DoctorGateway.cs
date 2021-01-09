using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Gateway.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Gateway
{
    public class DoctorGateway : IDoctorGateway
    {
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetDoctorService() + "/api/doctor/getAllDoctors")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    doctors = JsonConvert.DeserializeObject<List<Doctor>>(json.Result);
                });
            task.Wait();
            return doctors;
        }

        public  Doctor GetDoctorById(int doctorId)
        {
            Doctor doctor = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetDoctorService() + "/api/doctor/getDoctor/" + doctorId)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    doctor = JsonConvert.DeserializeObject<Doctor>(json.Result);
                });
            task.Wait();
            return doctor;
        }

        public string GetDoctorService()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "59947";

            return $"http://{origin}:{port}";
        }
    }
}
