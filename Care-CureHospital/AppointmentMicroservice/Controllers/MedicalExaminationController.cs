using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Gateway.Interface;
using AppointmentMicroservice.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationController : ControllerBase
    {
        private IMedicalExaminationService medicalExaminationService;
        private IDoctorGateway doctorGateway;
        private IPatientGateway patientGateway;

        public MedicalExaminationController(IMedicalExaminationService medicalExaminationService, IDoctorGateway doctorGateway, IPatientGateway patientGateway)
        {
            this.medicalExaminationService = medicalExaminationService;
            this.doctorGateway = doctorGateway;
            this.patientGateway = patientGateway;
        }

        [HttpGet("getMedicalExamination/{id}")]
        public IActionResult GetMedicalExamination(int id)
        {
            MedicalExamination medicalExamination = medicalExaminationService.GetEntity(id);
            if (medicalExamination == null)
            {
                return NotFound();
            }
            medicalExamination.Doctor = doctorGateway.GetDoctorById(medicalExamination.DoctorId);
            medicalExamination.Patient = patientGateway.GetPatientById(medicalExamination.PatientId);
            return Ok(medicalExamination);
        }
    }
}

