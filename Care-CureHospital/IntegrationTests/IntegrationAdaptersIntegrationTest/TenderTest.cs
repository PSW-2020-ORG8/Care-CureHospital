using Backend;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace IntegrationTests.IntegrationAdaptersIntegrationTest
{
    class TenderTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public TenderTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

     /*   [Theory]
        [MemberData(nameof(TenderData))]
        public async void Get_All_Tenders(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }*/
    }
}
