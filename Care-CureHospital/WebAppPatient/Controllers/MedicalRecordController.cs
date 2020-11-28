using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.PatientDoctor;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;
using WebAppPatient.Validation;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        public MedicalRecordController() { }

        [HttpPost]      // POST /api/medicalRecord
        public IActionResult Add(MedicalRecordDto dto)
        {
            MedicalRecordValidation medicalRecordValidation = new MedicalRecordValidation();
            if (!medicalRecordValidation.ValidateMedicalRecord(dto))
            {
                return BadRequest("The data which were entered are incorrect!");
            }

            MedicalRecord medicalRecord = MedicalRecordMapper.MedicalRecordDtoToMedicalRecord(dto);
            //App.Instance().EmailVerificationService.SendVerificationEmailLink(new MailAddress(dto.Patient.EMail), dto.Patient.Username);
            App.Instance().MedicalRecordService.CreatePatientMedicalRecord(new MailAddress(dto.Patient.EMail), medicalRecord);
            return Ok(200);
        }

        [HttpGet("getForPatient/{patientID}")]       // GET /api/medicalRecord/getForPatient/{id}
        public IActionResult GetMedicalRecordForPatient(int patientID) 
        {
            MedicalRecord medicalRecord = App.Instance().MedicalRecordService.GetMedicalRecordForPatient(patientID);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDto(medicalRecord));
            }
        }

        [HttpGet("activatePatientMedicalRecord/{username}")]       // GET /api/medicalRecord/activatePatientMedicalRecord/{username}
        public IActionResult ActivatePatientMedicalRecord(string username)
        {
            MedicalRecord medicalRecord = App.Instance().MedicalRecordService.GetMedicalRecordForPatientByUsername(username);
            if (medicalRecord == null)
            {
                return BadRequest();
            }
            App.Instance().MedicalRecordService.ActivatePatientMedicalRecord(medicalRecord);
            return Redirect("http://localhost:51182/index.html#/");

        }
    }
}
