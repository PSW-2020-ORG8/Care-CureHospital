using Microsoft.AspNetCore.Mvc;
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
            return Ok(patientService.GetEntity(patientId));
        }
    }
}
