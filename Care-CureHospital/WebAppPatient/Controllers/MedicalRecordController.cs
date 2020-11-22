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
            // validacije
            MedicalRecord medicalRecord = MedicalRecordMapper.MedicalRecordDtoToMedicalRecord(dto);
            App.Instance().MedicalRecordService.AddEntity(medicalRecord);
            return Ok(200);
        }
    }
}
