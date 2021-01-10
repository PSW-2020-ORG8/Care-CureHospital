using Newtonsoft.Json;
using RestSharp;
using System;

namespace Backend.Service.RequestServices
{
    public class UrgentOrderService
    {
        public static String SendRequestForOrder()
        {
            var client = new RestSharp.RestClient("http://localhost:8080");
            var request = new RestRequest("/urgentOrder/forMedicament");
            IRestResponse<String> response = client.Get<String>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            var result = response.Content;
            string jsonRes = JsonConvert.SerializeObject(result);
            return jsonRes;
        }    
    }
}
