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
    }
}
