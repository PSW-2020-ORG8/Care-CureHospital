using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Domain;
using UserMicroservice.Dto;
using UserMicroservice.Mapper;
using UserMicroservice.Service;

namespace UserMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService patientService;

        public PatientController(IPatientService patientService) {
     
            this.patientService = patientService;
        }

        /*
        [HttpGet()]       // GET /api/patient
        public IActionResult GetAllPatients(int patientId)
        {
            List<PatientDto> result = new List<PatientDto>();
            patientService.GetAllEntities().ToList().ForEach(patient => result.Add(PatientMapper.PatientToPatientDto(patient,
                appointmentService.CountCancelledAppointmentsForPatient(patient.Id, DateTime.Now))));
            return Ok(result);
        }

        [HttpGet("getMaliciousPatients")]       // GET /api/patient/getMaliciousPatients
        public IActionResult GetMaliciousPatients()
        {
            List<PatientDto> result = new List<PatientDto>();
            patientService.GetMaliciousPatients().ToList().ForEach(patient => result.Add(PatientMapper.PatientToPatientDto(patient,
                appointmentService.CountCancelledAppointmentsForPatient(patient.Id, DateTime.Now))));
            return Ok(result);
        }
        */
        [HttpPut("blockMaliciousPatient/{patientId}")]       // PUT /api/patient/blockMaliciousPatient/{patientId}
        public IActionResult BlockMaliciousPatient(int patientId)
        {
            return Ok(patientService.BlockMaliciousPatient(patientId));
        }

        [HttpGet("getPatient/{patientId}")]    // GET /api/patient/getPatient/{patientId}
        public IActionResult GetPatientById(int patientId)
        {
            Patient patient = patientService.GetEntity(patientId);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPut("setMaliciousPatient/{patientId}")]       // PUT /api/patient/setMaliciousPatient/{patientId}
        public IActionResult SetMaliciousPatient(int patientId)
        {
            return Ok(patientService.SetMaliciousPatient(patientId));
        }
    }
}
