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
    public class AllergiesController : ControllerBase
    {
        public AllergiesController() { }

        [HttpGet]       // GET /api/allergies
        public IActionResult GetAllAllergies()
        {
            List<Allergies> result = new List<Allergies>();
            App.Instance().AllergiesService.GetAllEntities().ToList().ForEach(allergy => result.Add(allergy));
            return Ok(result);
        }
    }
}
