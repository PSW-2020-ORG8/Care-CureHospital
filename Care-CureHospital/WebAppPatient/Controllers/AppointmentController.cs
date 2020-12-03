using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.AllActors;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        public AppointmentController() { }

        [HttpGet]
        public IActionResult GetAvailableAppointmentsByDateAndDoctorId()
        {
            return Ok();
        }

        [HttpGet("getAllSpecialization")]       // GET /api/appointment/getAllSpecialization
        public IActionResult GetAllSpecialization()
        {
            List<SpecializationDto> result = new List<SpecializationDto>();
            App.Instance().SpetialitationService.GetAllEntities().ToList().ForEach(specialization => result.Add(SpecializationMapper.SpecializationToSpecializationDto(specialization)));
            return Ok(result);
        }

        [HttpGet("getAllDoctorBySpecializationId/{specializationId}")]       // GET /api/appointment/getAllDoctorBySpecializationId/{specializationId}
        public IActionResult GetAllDoctorsBySpecializationId(int specializationId)
        {
            List<DoctorDto> result = new List<DoctorDto>();
            App.Instance().DoctorService.GetAllDoctorsBySpecialization(specializationId).ToList().ForEach(doctor => result.Add(DoctorMapper.DoctorToDoctorDto(doctor)));
            return Ok(result);
        }
    }
}
