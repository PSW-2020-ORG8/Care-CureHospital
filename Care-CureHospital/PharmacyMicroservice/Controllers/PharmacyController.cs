using Microsoft.AspNetCore.Mvc;
using PharmacyMicroservice.Domain;
using PharmacyMicroservice.Dto;
using PharmacyMicroservice.Mapper;
using PharmacyMicroservice.Service;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private IPharmacyService pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }

        [HttpPost]
        [Route("addPharmacy")]
        public IActionResult AddPharmacy([FromBody] PharmaciesDto dto)
        {
            Pharmacies pharmacy = PharmacyMapper.PharmacyDtoToPharmacy(dto);
            this.pharmacyService.AddEntity(pharmacy);
            return Ok();
        }

        [HttpGet]
        [Route("getPharmacies")]
        public IActionResult GetPharmacies()
        {
            List<PharmaciesDto> pdto = new List<PharmaciesDto>();
            this.pharmacyService.GetAllEntities().ToList().ForEach(pharmacy => pdto.Add(PharmacyMapper.PharmacyToPharmacyDto(pharmacy)));
            return Ok(pdto);
        }
    }
}