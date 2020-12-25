﻿using Backend;
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
            Console.WriteLine(expectedResponseStatusCode);
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