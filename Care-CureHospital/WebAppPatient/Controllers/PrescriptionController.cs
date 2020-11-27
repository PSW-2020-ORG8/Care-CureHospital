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
    public class PrescriptionController : ControllerBase
    {
        public PrescriptionController() { }

        [HttpGet]       // GET /api/prescription
        public IActionResult GetAllPrescriptions()
        {
            List<PrescriptionDto> result = new List<PrescriptionDto>();
            App.Instance().PrescriptionService.GetAllEntities().ToList().ForEach(prescription => result.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription)));
            return Ok(result);
        }

        [HttpGet("getForPatient/{patientID}")]       // GET /api/prescription/getForPatient/{id}
        public IActionResult GetPrescriptionsForPatient(int patientID)
        {
            List<PrescriptionDto> prescriptionsForPatient = new List<PrescriptionDto>();
            App.Instance().PrescriptionService.GetPrescriptionsForPatient(patientID).ToList().ForEach(prescription => prescriptionsForPatient.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription)));
            return Ok(prescriptionsForPatient);
        }
    }
}
