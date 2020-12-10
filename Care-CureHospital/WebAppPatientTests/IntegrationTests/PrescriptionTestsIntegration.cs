using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppPatient;
using Xunit;

namespace WebAppPatientTests.IntegrationTests
{
    public class PrescriptionTestsIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public PrescriptionTestsIntegration(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }
    }
}
