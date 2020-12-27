using IntegrationAdapters.Dto;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        public static async Task SendRequest(string option)
        {
            SendGetRequestWithRestSharp();
        }
        private static void SendGetRequestWithRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:8080");
            var request = new RestRequest("/medicament/Aspirin");
            var response = client.Get<List<MedicamentDto>>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            List<MedicamentDto> result = response.Data;
            result.ForEach(medicament => Console.WriteLine(medicament.ToString()));
         }
    }
}
 