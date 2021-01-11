using Newtonsoft.Json;
using ProtocolMicroservice.Domain;
using RestSharp;
using System;
using System.Net;

namespace ProtocolMicroservice.Service
{
    public class UrgentOrderService
    {
        /*public static String SendRequestForOrder()
        {
            var client = new RestSharp.RestClient("http://localhost:8080");
            var request = new RestRequest("/urgentOrder/forMedicament");
            IRestResponse<String> response = client.Get<String>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            var result = response.Content;
            string jsonRes = JsonConvert.SerializeObject(result);
            return jsonRes;
        }*/

        public String CreateOrder(UrgentMedicineOrder order)
        {
            return order.Name + ":" + order.Quantity.ToString();

        }

        public void SendUrgentOrder(String order)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadString(new Uri(@"http://localhost:8080/order/urgent/http"), "POST", order);
            client.Dispose();
        }

        public Boolean SendOrderHttp(UrgentMedicineOrder order)
        {
            try
            {
                SendUrgentOrder(CreateOrder(order));
                return true;
            }
            catch (Exception e) 
            { 
                return false; 
            }
        }
    }
}