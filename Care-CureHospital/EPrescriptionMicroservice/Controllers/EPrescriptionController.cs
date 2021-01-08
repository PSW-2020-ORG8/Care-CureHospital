using EPrescriptionMicroservice.Service;
using EPrescriptionMicroservice.Domain;
using EPrescriptionMicroservice.Dto;
using EPrescriptionMicroservice.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EPrescriptionMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EPrescriptionController : ControllerBase
    {
        private IEPrescriptionService ePrescriptionService;
        public EPrescriptionController(IEPrescriptionService ePrescriptionService) 
        {
            this.ePrescriptionService = ePrescriptionService;
        }

        [HttpGet]
        public IActionResult GetAllEPrescription()
        {
            List<EPrescriptionDto> result = new List<EPrescriptionDto>();
            this.ePrescriptionService.GetAllEntities().ToList().ForEach(eprescription => result.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddEPrescription(EPrescriptionDto dto)
        {
            EPrescription eprescription = EPrescriptionMapper.EPrescriptionDtoToEPrescription(dto);
            this.ePrescriptionService.AddEntity(eprescription);
            return Ok();
        }

        [HttpGet("getForPatient/{patientID}")]
        public IActionResult GetEPrescriptionsForPatient(int patientID)
        {
            List<EPrescriptionDto> eprescriptionsForPatient = new List<EPrescriptionDto>();
           this.ePrescriptionService.GetEPrescriptionsForPatient(patientID).ToList().ForEach(eprescription => eprescriptionsForPatient.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(eprescriptionsForPatient);
        }

        /*[HttpGet("findePrescriptionsByDate")]
        public IActionResult FindePrescriptionsByDate([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "date")] string date)
        {
            List<EPrescriptionDto> result = new List<EPrescriptionDto>();
            this.ePrescriptionService.FindEPrescriptionsForDateParameter(patientId, date).ToList().ForEach(eprescription => result.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(result);
        }*/

        [HttpGet("findEPrescriptionsByComment")]
        public IActionResult FindPrescriptionsByComment([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "comment")] string comment)
        {
            List<EPrescriptionDto> result = new List<EPrescriptionDto>();
            this.ePrescriptionService.FindEPrescriptionsForCommentParameter(patientId, comment).ToList().ForEach(eprescription => result.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(result);
        }

        [HttpPost("send")]
        public IActionResult SendPrescription()
        {
            this.ePrescriptionService.SendPrescriptionSftp();
            return Ok();
        }
    }
}

