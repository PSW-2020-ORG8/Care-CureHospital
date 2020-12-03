using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using WebAppPatient;
using Xunit;

namespace WebAppPatientTests.IntegrationTests
{
    public class SurveyTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        /*
        private readonly WebApplicationFactory<Startup> factory;

        public SurveyTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Get_survey_results(HttpStatusCode expectedAnswer)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/getSurveyResults");

            response.StatusCode.ShouldBeEquivalentTo(expectedAnswer);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Get_survey_results_for_doctors(HttpStatusCode expectedAnswer)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/survey/getSurveyResultsForDoctors");

            response.StatusCode.ShouldBeEquivalentTo(expectedAnswer);
        }



        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {  HttpStatusCode.OK }
        };
        */
    }
}
