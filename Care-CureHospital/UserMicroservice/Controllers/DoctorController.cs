using System.Collections.Generic;
using System.Linq;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Domain;
using UserMicroservice.Dto;
using UserMicroservice.Mapper;
using UserMicroservice.Service;

namespace UserMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService doctorService;
        private ISpecializationService specializationService;
        private IDomainEventService domainEventService;

        public DoctorController(IDoctorService doctorService, ISpecializationService specializationService, IDomainEventService domainEventService) {
            this.doctorService = doctorService;
            this.specializationService = specializationService;
            this.domainEventService = domainEventService;
        }

        [HttpGet("getAllDoctorBySpecializationId/{specializationId}")]       // GET /api/doctor/getAllDoctorBySpecializationId/{specializationId}
        public IActionResult GetAllDoctorsBySpecializationId(int specializationId)
        {
            domainEventService.Save(new URLEvent("/api/doctor/getAllDoctorBySpecializationId/{specializationId}", "GET"));
            List<DoctorDto> result = new List<DoctorDto>();
            doctorService.GetAllDoctorsBySpecialization(specializationId).ToList().ForEach(doctor => result.Add(DoctorMapper.DoctorToDoctorDto(doctor)));
            return Ok(result);
        }

        [HttpGet("getAllSpecialization")]       // GET /api/doctor/getAllSpecialization
        public IActionResult GetAllSpecialization()
        {
            domainEventService.Save(new URLEvent("/api/doctor/getAllSpecialization", "GET"));
            List<SpecializationDto> result = new List<SpecializationDto>();
            specializationService.GetAllEntities().ToList().ForEach(specialization => result.Add(SpecializationMapper.SpecializationToSpecializationDto(specialization)));
            return Ok(result);
        }

        [HttpGet("getAllDoctors")]       // GET /api/doctor/getAllDoctors
        public IActionResult GetAllDoctors()
        {
            domainEventService.Save(new URLEvent("/api/doctor/getAllDoctors", "GET"));
            return Ok(doctorService.GetAllEntities());
        }

        [HttpGet("getDoctor/{doctorId}")]       // GET /api/doctor/getDoctor/{doctorId}
        public IActionResult GetDoctor(int doctorId)
        {
            domainEventService.Save(new URLEvent("/api/doctor/getDoctor/{doctorId}}", "GET"));
            Doctor doctor = doctorService.GetEntity(doctorId);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
    }
}
