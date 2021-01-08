using AppointmentMicroservice.Domain;
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
            MedicalExamination medicalExamination = medicalExaminationService.GetEntity(id);
            if (medicalExamination == null)
            {
                return NotFound();
            }
            return Ok(medicalExamination);
        }
    }
}

