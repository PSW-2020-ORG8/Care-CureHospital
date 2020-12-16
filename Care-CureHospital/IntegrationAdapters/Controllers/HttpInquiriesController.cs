using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntegrationAdapters.Dto;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpInquiriesController : ControllerBase
    {
        public static async Task SendRequest(int option)
        {
            switch (option)
            {
                case 1:
                    SendGetRequestWithRestSharp();
                    break;
            }
        }
        private static void SendGetRequestWithRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:8080");
            var request = new RestRequest("/medicament");
            var response = client.Get<List<MedicamentDto>>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            List<MedicamentDto> result = response.Data;
            result.ForEach(medicament => Console.WriteLine(medicament.ToString()));
        }
    }
}
 