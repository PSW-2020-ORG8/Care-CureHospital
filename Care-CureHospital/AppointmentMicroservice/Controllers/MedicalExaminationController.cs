using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentMicroservice.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationController : ControllerBase
    {
        private IMedicalExaminationService medicalExaminationService;

        public MedicalExaminationController(IMedicalExaminationService medicalExaminationService)
        {
            this.medicalExaminationService = medicalExaminationService;
        }

        [HttpGet("getMedicalExamination/{id}")]
        public IActionResult GetMedicalExamination(int id)
        {   
            return Ok(medicalExaminationService.GetEntity(id));
        }
    }
}

