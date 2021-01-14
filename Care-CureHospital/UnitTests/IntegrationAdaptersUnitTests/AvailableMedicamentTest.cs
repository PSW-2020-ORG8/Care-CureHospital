using RestSharp;
using System.Net;
using Xunit;

namespace UnitTests.IntegrationAdaptersUnitTests
{
    public class AvailableMedicamentTest
    {
        [Fact]
        public void Send_request_with_rest_sharp()
        {
            RestClient restClient = new RestClient("http://localhost:8080");
            RestRequest restRequest = new RestRequest("/medicament/Aspirin", DataFormat.Json);

            IRestResponse response = restClient.Execute(restRequest);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Not_sent_request_with_rest_sharp()
        {
            RestClient restClient = new RestClient("http://localhost:4001");
            RestRequest restRequest = new RestRequest("/medicament/quantity", DataFormat.Json);

            IRestResponse response = restClient.Execute(restRequest);

            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
