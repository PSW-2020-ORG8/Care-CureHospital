using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Gateway.Interface;
using AppointmentMicroservice.Service;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
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
        private IDomainEventService domainEventService;

        public MedicalExaminationController(IMedicalExaminationService medicalExaminationService, IDoctorGateway doctorGateway, IPatientGateway patientGateway, IDomainEventService domainEventService)
        {
            this.medicalExaminationService = medicalExaminationService;
            this.doctorGateway = doctorGateway;
            this.patientGateway = patientGateway;
            this.domainEventService = domainEventService;
        }

        [HttpGet("getMedicalExamination/{id}")]
        public IActionResult GetMedicalExamination(int id)
        {
            domainEventService.Save(new URLEvent("/api/Appointment/getMedicalExamination/" + id, "GET"));

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

