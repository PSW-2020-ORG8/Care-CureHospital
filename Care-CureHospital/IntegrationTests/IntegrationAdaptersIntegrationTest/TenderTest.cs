using IntegrationAdapters;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace IntegrationTests.IntegrationAdaptersIntegrationTest
{
    public class TenderTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public TenderTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(TenderData))]
        public async void Get_All_Tenders(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/tender/allTender");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(TenderData))]
        public async void Get_All_Active_Tenders(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/tender/getActiveTender");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(TenderData))]
        public async void Get_All_Inactive_Tenders(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/tender/getInactiveTender");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(CloseTenderData))]
        public async void Close_Tender(int tenderId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.PutAsync("/api/tender/closeTender/" + tenderId, new StringContent("1", Encoding.UTF8, "application/json"));

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> TenderData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { HttpStatusCode.OK });
            return retVal;
        }

        public static IEnumerable<object[]> CloseTenderData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 2, HttpStatusCode.OK });
            return retVal;
        }
    }
}
