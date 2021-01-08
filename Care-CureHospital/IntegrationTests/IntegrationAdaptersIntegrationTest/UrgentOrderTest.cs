using IntegrationAdapters;
using Microsoft.AspNetCore.Mvc.Testing;
using RestSharp;
using Shouldly;
using System.Net;
using Xunit;

namespace IntegrationTests.IntegrationAdaptersIntegrationTest
{
    public class UrgentOrderTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public UrgentOrderTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public void Send_Request()
        {
            RestClient restClient = new RestClient("http://localhost:8080");
            RestRequest restRequest = new RestRequest("/urgentOrder/forMedicament");

            IRestResponse response = restClient.Execute(restRequest);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }
    }
}
