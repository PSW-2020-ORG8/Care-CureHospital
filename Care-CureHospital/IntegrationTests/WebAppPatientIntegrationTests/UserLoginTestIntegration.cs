using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using UserMicroservice;
using UserMicroservice.Dto;

namespace IntegrationTests.WebAppPatientIntegrationTests
{
    public class UserLoginTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public UserLoginTestIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [MemberData(nameof(PatientData))]
        public async void Successful_Patient_Login(AuthenticateDto dto, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.PostAsync("/api/user/login", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        [Theory]
        [MemberData(nameof(SystemAdministratorData))]
        public async void Successful_System_Administrator_Login(AuthenticateDto dto, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.PostAsync("/api/user/login", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> PatientData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new AuthenticateDto("zika", "123") , HttpStatusCode.OK });
            retVal.Add(new object[] { new AuthenticateDto("zika", "321") , HttpStatusCode.Unauthorized });
            retVal.Add(new object[] { new AuthenticateDto("minja", "123") , HttpStatusCode.Unauthorized });
            return retVal;
        }

        public static IEnumerable<object[]> SystemAdministratorData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new AuthenticateDto("admin1", "admin1"), HttpStatusCode.OK });
            retVal.Add(new object[] { new AuthenticateDto("admin1", "321"), HttpStatusCode.Unauthorized });
            retVal.Add(new object[] { new AuthenticateDto("minja", "admin1"), HttpStatusCode.Unauthorized });
            return retVal;
        }
    }
}
