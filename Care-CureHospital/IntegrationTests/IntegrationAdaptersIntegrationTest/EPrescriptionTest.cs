using IntegrationAdapters;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace IntegrationTests.IntegrationAdaptersIntegrationTest
{
    public class EPrescriptionTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public EPrescriptionTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(EPrescriptionD))]
        public async void Get_All_EPrescriptions(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/eprescription");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(EPrescriptionData))]
        public async void Find_EPrescriptions_For_Patient_Id(int patientId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/eprescription/getForPatient/" + patientId);

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(EPrescriptionD))]
        public async void Find_EPrescriptions_By_Comment(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/eprescription/findEPrescriptionsByComment");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(EPrescriptionD))]
        public async void Find_EPrescriptions_By_Date(HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/eprescription/findePrescriptionsByDate");

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> EPrescriptionData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 1, HttpStatusCode.OK });
            return retVal;
        }

        public static IEnumerable<object[]> EPrescriptionD()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { HttpStatusCode.OK });
            return retVal;
        }
    }
}
