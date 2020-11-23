using System;
using System.Collections.Generic;
using System.Linq;
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
            App.Instance().MedicalRecordService.AddEntity(medicalRecord);
            return Ok(200);
        }
    }
}
