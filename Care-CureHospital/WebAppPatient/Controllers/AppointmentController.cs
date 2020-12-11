﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Term;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;
using WebAppPatient.Validation;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public AppointmentController() { }

        [HttpGet("getAvailableAppointments")]
        public IActionResult GetAvailableAppointmentsByDateAndDoctorId([FromQuery(Name = "date")] string date, [FromQuery(Name = "doctorId")] int doctorId)
        {
            DoctorWorkDayDto dto = DoctorWorkDayMapper.DoctorWorkDayToDoctorWorkDayDto(
                App.Instance().DoctorWorkDayService.GetDoctorWorkDayByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), doctorId),
                App.Instance().DoctorWorkDayService.GetAvailableAppointmentsByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), doctorId));
            
            if (dto == null)
            {
                return NoContent();
            }
            return Ok(dto);
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

        [HttpPost]       // POST /api/appointment/
        public IActionResult ScheduleAppointment(SchedulingAppointmentDto dto)
        {
            if (App.Instance().DoctorWorkDayService.ScheduleAppointment(SchedulingAppointmentMapper.AppointmentDtoToAppointment(dto)))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("getPreviousAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getPreviousAppointmetsByPatient/{patientId}
        public IActionResult GetPreviousAppointmetsByPatient(int patientId)
        {
            List<AppointmentDto> result = new List<AppointmentDto>();
            App.Instance().AppointmentService.GetPreviousAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment)));
            return Ok(result);
        }

        [HttpGet("getScheduledAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getScheduledAppointmetsByPatient/{patientId}
        public IActionResult GetScheduledAppointmetsByPatient(int patientId)
        {
            List<AppointmentDto> result = new List<AppointmentDto>();
            App.Instance().AppointmentService.GetScheduledAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment)));
            return Ok(result);
        }

        [HttpPut("cancelAppointment/{appointmentId}")]       // GET /api/appointment/cancelAppointment/{appointmentId}
        public IActionResult CancelPatientAppointment(int appointmentId)
        {
            return Ok(App.Instance().AppointmentService.CancelPatientAppointment(appointmentId, DateTime.Now));
        }

        [HttpGet("getAllRecommendedTerms")]       // GET /api/appointment/getAllRecommendedTerms
        public IActionResult GetAllRecommendedTerms([FromQuery(Name = "startDate")] string startDate, [FromQuery(Name = "endDate")] string endDate, [FromQuery(Name = "doctorId")] string doctorId, [FromQuery(Name = "priority")] string priority)
        {
            try
            {
                Dictionary<int, List<Appointment>> availableAppointments = App.Instance().DoctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture), DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture), Int32.Parse(doctorId), priority);
                return Ok(DoctorWorkDayMapper.CreateDoctorWorkDayDtos(App.Instance().DoctorWorkDayService.GetDoctorWorkDaysByIds(availableAppointments.Keys.ToList()), availableAppointments));
            }
            catch
            {
                return BadRequest("The data which were entered are incorrect!");
            }           
        }
    }
}
