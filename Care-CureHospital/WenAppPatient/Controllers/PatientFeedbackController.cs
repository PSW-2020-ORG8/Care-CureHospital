using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Model;

namespace WenAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbackController : ControllerBase
    {
        private readonly HealthClinicDbContext dbContext;
        public PatientFeedbackController(HealthClinicDbContext context)
        {
            this.dbContext = context;
        }
    }
}
