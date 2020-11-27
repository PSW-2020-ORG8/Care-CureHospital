using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.BlogAndNotification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Model.DoctorMenager;
using Service.MedicamentService;
using Backend.Model.DoctorMenager;
using IntegrationAdapters.Dto;
using Backend.Service.DirectorService;

namespace IntegrationAdapters.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReportController:ControllerBase
    {

        public ReportController() { }
        

    }
}
