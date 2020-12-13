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
    public class AppointmentTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public AppointmentTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(AppointmentData))]
        public async void Get_Previous_Appointments_Status_Code_Test(int patientId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/appointment/getPreviousAppointmetsByPatient/" + patientId);

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentData))]
        public async void Get_Scheduled_Appointments_Status_Code_Test(int patientId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.GetAsync("/api/appointment/getScheduledAppointmetsByPatient/" + patientId);

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentData))]
        public async void Cancel_Appointment_Status_Code_Test(int appointmentId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            var response = await client.PutAsync("/api/appointment/cancelAppointment/" + appointmentId, new StringContent("1", Encoding.UTF8, "application/json"));

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> AppointmentData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 1, HttpStatusCode.OK });
            retVal.Add(new object[] { 15, HttpStatusCode.NotFound });
            return retVal;
        }

    }
}
