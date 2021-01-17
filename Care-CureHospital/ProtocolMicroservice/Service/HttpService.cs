using ProtocolMicroservice.Dto;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ProtocolMicroservice.Service
{
    public class HttpService
    {
        public static String SendGetRequestWithRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:8080");
            var request = new RestRequest("/medicament/Aspirin", DataFormat.Json);
            IRestResponse<List<MedicamentDto>> response = client.Get<List<MedicamentDto>>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Error occured while sending request. {response.Content}" +
                    $"{response.StatusDescription}");
            }
            response.Data.ForEach(medicament =>
            Console.WriteLine(medicament.ToString()));
            var result = response.Content;
            return result;
        }
    }
}