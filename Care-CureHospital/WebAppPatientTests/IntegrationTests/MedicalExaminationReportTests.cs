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
    public class MedicalExaminationReportTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        //private readonly WebApplicationFactory<Startup> factory;

        //public MedicalExaminationReportTests(WebApplicationFactory<Startup> factory)
        //{
        //    this.factory = factory;
        //}

        //[Theory]
        //[MemberData(nameof(Data))]
        //public async void Find_Reports_With_Doctor_Searh_Parameter(HttpStatusCode expectedAnswer)
        //{
        //    HttpClient client = factory.CreateClient();

        //    HttpResponseMessage response = await client.GetAsync("/api/medicalExaminationReport/findReportsByDoctor?patientId=1&doctor=Aleksandar");

        //    response.StatusCode.ShouldBeEquivalentTo(expectedAnswer);
        //}

        //public static IEnumerable<object[]> Data =>
        //new List<object[]>
        //{
        //    new object[] {  HttpStatusCode.OK }
        //};
    }
}
