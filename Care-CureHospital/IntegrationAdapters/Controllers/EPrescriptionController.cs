using Backend;
using Backend.Model.PatientDoctor;
using IntegrationAdapters.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Service.DoctorService;
using IntegrationAdapters.Mapper;
namespace IntegrationAdapters.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class EPrescriptionController : ControllerBase
    {
        public EPrescriptionController() { }

        [HttpGet]
        public IActionResult GetAllEPrescription()
        {
            List<EPrescriptionDto> result = new List<EPrescriptionDto>();

            App.Instance().EPrescriptionService.GetAllEntities().ToList().ForEach(eprescription => result.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(result);
        }

        [HttpPost]   //POST /api/eprescription
        public IActionResult AddEPrescription(EPrescriptionDto dto)
        {
            EPrescription eprescription = EPrescriptionMapper.EPrescriptionDtoToEPrescription(dto, null);
            App.Instance().EPrescriptionService.AddEntity(eprescription);
            return Ok();
        }
    }
}
