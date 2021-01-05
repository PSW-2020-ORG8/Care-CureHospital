using IntegrationAdapters.Dto;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Backend.Service.RequestServices
{
    public class HttpService
    {
        public static String SendGetRequestWithRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:8080");
            var request = new RestRequest("/medicament/Aspirin", DataFormat.Json);
            IRestResponse<List<MedicamentDto>> response = client.Get<List<MedicamentDto>>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            response.Data.ForEach(medicament =>
            Console.WriteLine(medicament.ToString()));
            Console.WriteLine(response.Content);
            var result = response.Content;
            return result;
        }
    }
}
