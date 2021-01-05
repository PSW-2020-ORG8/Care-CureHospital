using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

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
            //return result;
        }

       /* public void SendOrder(String order)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadString(new Uri(@"http://localhost:8080/order/urgentHttp", order));
            client.Dispose();
        }*/
    }
}
