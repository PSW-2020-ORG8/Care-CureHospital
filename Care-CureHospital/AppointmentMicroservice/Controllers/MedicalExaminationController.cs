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
        private MedicalExaminationService medicalExaminationService;

        public MedicalExaminationController(MedicalExaminationService medicalExaminationService)
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

