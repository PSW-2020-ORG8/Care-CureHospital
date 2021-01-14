using IntegrationAdapters;
using Microsoft.AspNetCore.Mvc.Testing;
using RestSharp;
using Shouldly;
using System.Net;
using Xunit;

namespace IntegrationTests.IntegrationAdaptersIntegrationTest
{
    public class AvailableMedicamentTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public AvailableMedicamentTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public void Send_Request()
        {
            RestClient restClient = new RestClient("http://localhost:8080");
            RestRequest restRequest = new RestRequest("/medicament/Aspirin");

            IRestResponse response = restClient.Execute(restRequest);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }
    }
}
