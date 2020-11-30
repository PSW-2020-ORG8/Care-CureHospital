using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using Xunit;
using Shouldly;
using System.Threading.Tasks;

namespace IntegrationAdaptersTests.IntegrationTests
{
    public class ReportTest : IClassFixture<WebApplicationFactory<IntegrationAdapters.Startup>>
    {
        private readonly WebApplicationFactory<IntegrationAdapters.Startup> _factory;

        public ReportTest(WebApplicationFactory<IntegrationAdapters.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Report()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
