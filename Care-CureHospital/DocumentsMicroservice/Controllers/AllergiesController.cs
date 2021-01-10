using DocumentsMicroservice.Dto;
using DocumentsMicroservice.Mapper;
using DocumentsMicroservice.Service;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DocumentsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private IAllergiesService allergiesService;
        private IDomainEventService domainEventService;

        public AllergiesController(IAllergiesService allergiesService, IDomainEventService domainEventService) 
        {
            this.allergiesService = allergiesService;
            this.domainEventService = domainEventService;
        }

        [HttpGet]       // GET /api/allergies
        public IActionResult GetAllAllergies()
        {
            domainEventService.Save(new URLEvent("/api/allergies", "GET"));
            List<AllergiesDto> result = new List<AllergiesDto>();
            this.allergiesService.GetAllEntities().ToList().ForEach(allergy => result.Add(AllergiesMapper.AllergiesToAllergiesDto(allergy)));
            return Ok(result);
        }
    }
}
