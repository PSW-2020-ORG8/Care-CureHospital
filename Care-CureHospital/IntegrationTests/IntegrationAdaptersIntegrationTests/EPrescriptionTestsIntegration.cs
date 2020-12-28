using Backend;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace IntegrationTests.IntegrationAdaptersIntegrationTests
{
    public class EPrescriptionTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public EPrescriptionTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(EPrescriptionData))]
        public async void Get_All_Eprescription_By_Patient_Id(int patientId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/eprescription/getForPatient/" + patientId);

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
            
        }

        [Fact]
        public async void Get_All_Eprescription_By_Date()
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/eprescription/findePrescriptionsByDate?date=2020-11-26T10:30:00");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async void Get_All_Eprescription_By_Comment()
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/eprescription/findePrescriptionsByDate?comment=Ne preskacite konzumiranje leka");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        public static IEnumerable<object[]> EPrescriptionData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] {1,  HttpStatusCode.OK});
            retVal.Add(new object[] { 2, HttpStatusCode.NotFound });
            return retVal;
        }
    }
}
