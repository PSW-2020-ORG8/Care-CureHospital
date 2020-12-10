using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppPatient;
using Xunit;

namespace WebAppPatientTests.IntegrationTests
{
    public class DoctorWorkDayTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public DoctorWorkDayTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }
    }
}
