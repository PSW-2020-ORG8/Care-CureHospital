using Backend;
using Backend.Model.PatientDoctor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationReportController : ControllerBase
    {
        public MedicalExaminationReportController() { }

        [HttpGet]       // GET /api/medicalExaminationReport
        public IActionResult GetAllMedicalExaminationReports()
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            App.Instance().MedicalExaminationReportService.GetAllEntities().ToList().ForEach(medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }

        [HttpGet("getForPatient/{patientID}")]       // GET /api/medicalExaminationReport/getForPatient/{id}
        public IActionResult GetMedicalExaminationReportsForPatient(int patientID)
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            App.Instance().MedicalExaminationReportService.GetMedicalExaminationReportsForPatient(patientID).ToList().ForEach(
                medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }
    }
}
