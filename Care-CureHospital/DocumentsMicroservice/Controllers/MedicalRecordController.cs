using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Dto;
using DocumentsMicroservice.Gateway.Interface;
using DocumentsMicroservice.Mapper;
using DocumentsMicroservice.Service;
using DocumentsMicroservice.Validation;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace DocumentsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private IMedicalRecordService medicalRecordService;
        private IPatientGateway patientGateway;
        private IDomainEventService domainEventService;
        public MedicalRecordController(IMedicalRecordService medicalRecordService, IPatientGateway patientGateway, IDomainEventService domainEventService) 
        {
            this.medicalRecordService = medicalRecordService;
            this.patientGateway = patientGateway;
            this.domainEventService = domainEventService;
        }

        [HttpPost]      // POST /api/medicalRecord
        public IActionResult RegisterPatient(MedicalRecordDto dto)
        {
            domainEventService.Save(new URLEvent("/api/medicalRecord", "POST"));
            MedicalRecordValidation medicalRecordValidation = new MedicalRecordValidation(this.patientGateway);
            if (!medicalRecordValidation.ValidateMedicalRecord(dto))
            {
                return BadRequest("The data which were entered are incorrect!");
            }
            this.medicalRecordService.CreatePatientMedicalRecord(new MailAddress(dto.Patient.EMail), MedicalRecordMapper.MedicalRecordDtoToMedicalRecord(dto), dto.Patient.Username);
            this.medicalRecordService.WritePatientProfilePictureInFile(dto.Patient.Username, dto.ProfilePicture);
            return Ok(200);
        }

        [HttpGet("getForPatient/{patientID}")]       // GET /api/medicalRecord/getForPatient/{id}
        public IActionResult GetMedicalRecordForPatient(int patientID)
        {
            domainEventService.Save(new URLEvent("/api/medicalRecord/getForPatient/" + patientID, "GET"));
            MedicalRecord medicalRecord = this.medicalRecordService.GetMedicalRecordForPatient(patientID);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDto(medicalRecord, patientGateway.GetPatientById(medicalRecord.PatientId)));
            }
        }

        [HttpGet("activatePatientMedicalRecord/{username}")]       // GET /api/medicalRecord/activatePatientMedicalRecord/{username}
        public IActionResult ActivatePatientMedicalRecord(string username)
        {
            domainEventService.Save(new URLEvent("/api/medicalRecord/activatePatientMedicalRecord/" + username, "GET"));
            MedicalRecord medicalRecord = this.medicalRecordService.FindPatientMedicalRecord(this.patientGateway.GetPatientByUsername(username));
            if (medicalRecord == null)
            {
                return BadRequest();
            }
            this.medicalRecordService.ActivatePatientMedicalRecord(medicalRecord.Id);
            return Redirect("http://localhost:60370/index.html#/userLogin");
        }
    }
}
