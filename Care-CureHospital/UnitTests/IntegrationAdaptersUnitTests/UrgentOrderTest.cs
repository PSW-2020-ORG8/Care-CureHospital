using RestSharp;
using System.Net;
using Xunit;

namespace UnitTests.IntegrationAdaptersUnitTests
{
    public class UrgentOrderTest
    {
        [Fact]
        public void Send_request_for_urgent_order()
        {
            RestClient restClient = new RestClient("http://localhost:8080");
            RestRequest restRequest = new RestRequest("/urgentOrder/forMedicament");

            IRestResponse response = restClient.Execute(restRequest);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Not_sent_request_for_urgent_order()
        {
            RestClient restClient = new RestClient("http://localhost:4001");
            RestRequest restRequest = new RestRequest("/urgentOrder/");

            IRestResponse response = restClient.Execute(restRequest);

            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
