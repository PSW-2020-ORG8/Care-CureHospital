using System.Collections.Generic;
using System.Linq;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Domain;
using UserMicroservice.Dto;
using UserMicroservice.Interface.Gateway;
using UserMicroservice.Mapper;
using UserMicroservice.Service;

namespace UserMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService patientService;
        private IAppointmentGateway appointmentGateway;
        private IDomainEventService domainEventService;

        public PatientController(IPatientService patientService, IAppointmentGateway appointmentGateway, IDomainEventService domainEventService) {
     
            this.patientService = patientService;
            this.appointmentGateway = appointmentGateway;
            this.domainEventService = domainEventService;
        }

        
        [HttpGet()]       // GET /api/patient
        public IActionResult GetAllPatients(int patientId)
        {
            domainEventService.Save(new URLEvent("/api/patient", "GET"));
            List<PatientDto> result = new List<PatientDto>();
            patientService.GetAllEntities().ToList().ForEach(patient => result.Add(PatientMapper.PatientToPatientDto(patient,
                appointmentGateway.CountCancelledAppointmentsForPatient(patient.Id))));
            return Ok(result);
        }

        [HttpGet("getMaliciousPatients")]       // GET /api/patient/getMaliciousPatients
        public IActionResult GetMaliciousPatients()
        {
            domainEventService.Save(new URLEvent("/api/patient/getMaliciousPatients", "GET"));
            List<PatientDto> result = new List<PatientDto>();
            patientService.GetMaliciousPatients().ToList().ForEach(patient => result.Add(PatientMapper.PatientToPatientDto(patient,
                appointmentGateway.CountCancelledAppointmentsForPatient(patient.Id))));
            return Ok(result);
        }
        
        [HttpPut("blockMaliciousPatient/{patientId}")]       // PUT /api/patient/blockMaliciousPatient/{patientId}
        public IActionResult BlockMaliciousPatient(int patientId)
        {
            domainEventService.Save(new URLEvent("/api/patient/blockMaliciousPatient/" + patientId, "PUT"));
            return Ok(patientService.BlockMaliciousPatient(patientId));
        }

        [HttpGet("getPatient/{patientId}")]    // GET /api/patient/getPatient/{patientId}
        public IActionResult GetPatientById(int patientId)
        {
            domainEventService.Save(new URLEvent("/api/patient/getPatient/" + patientId, "GET"));
            Patient patient = patientService.GetEntity(patientId);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet("getPatientByUsername/{username}")]    // GET /api/patient/getPatientByUsername/{username}
        public IActionResult GetPatientByUsername(string username)
        {
            Patient patient = patientService.GetPatientByUsername(username);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPut("setMaliciousPatient/{patientId}")]       // PUT /api/patient/setMaliciousPatient/{patientId}
        public IActionResult SetMaliciousPatient(int patientId)
        {
            domainEventService.Save(new URLEvent("/api/patient/setMaliciousPatient/" + patientId, "PUT"));
            return Ok(patientService.SetMaliciousPatient(patientId));
        }

        [HttpGet("doesUsernameExist/{username}")]    // GET /api/patient/doesUsernameExist/{username}
        public IActionResult DoesUsernameExist(string username)
        {
            domainEventService.Save(new URLEvent("/api/patient/doesUsernameExist/" +  username, "GET"));

            return Ok(patientService.DoesUsernameExist(username));
        }

        [HttpPost("addPateint")]    // GET /api/patient/addPateint
        public IActionResult AddPatient(Patient patient)
        {
            return Ok(patientService.AddEntity(patient));
        }
    }
}
