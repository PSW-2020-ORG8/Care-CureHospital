using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Dto;
using AppointmentMicroservice.Gateway.Interface;
using AppointmentMicroservice.Mapper;
using AppointmentMicroservice.Service;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IDoctorWorkDayService doctorWorkDayService;
        private IAppointmentService appointmentService;
        private IDoctorGateway doctorGateway;
        private IDomainEventService domainEventService;

        public AppointmentController(IDoctorWorkDayService doctorWorkDayService, IAppointmentService appointmentService, IDoctorGateway doctorGateway, IDomainEventService domainEventService) 
        {
            this.doctorWorkDayService = doctorWorkDayService;
            this.appointmentService = appointmentService;
            this.doctorGateway = doctorGateway;
            this.domainEventService = domainEventService;
        }

        [HttpGet("getAvailableAppointments")]
        public IActionResult GetAvailableAppointmentsByDateAndDoctorId([FromQuery(Name = "date")] string date, [FromQuery(Name = "doctorId")] int doctorId)
        {
            domainEventService.Save(new URLEvent("/api/Appointment/getAvailableAppointments", "GET"));
            DoctorWorkDayDto dto = DoctorWorkDayMapper.DoctorWorkDayToDoctorWorkDayDto(
                doctorWorkDayService.GetDoctorWorkDayByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), doctorId),
                doctorWorkDayService.GetAvailableAppointmentsByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), doctorId),
                doctorGateway.GetDoctorById(doctorId));

            if (dto == null)
            {
                return NoContent();
            }
            return Ok(dto);
        }

        [HttpPost]       // POST /api/appointment/
        public IActionResult ScheduleAppointment(SchedulingAppointmentDto dto)
        {
            domainEventService.Save(new URLEvent("/api/Appointment", "POST"));
            if (doctorWorkDayService.ScheduleAppointment(SchedulingAppointmentMapper.AppointmentDtoToAppointment(dto)))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("getPreviousAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getPreviousAppointmetsByPatient/{patientId}
        public IActionResult GetPreviousAppointmentsByPatient(int patientId)
        {
            domainEventService.Save(new URLEvent("/api/Appointment/getPreviousAppointmetsByPatient/" + patientId, "GET"));
            List<AppointmentDto> result = new List<AppointmentDto>();
            appointmentService.GetPreviousAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment, doctorGateway.GetDoctorById(appointment.MedicalExamination.DoctorId))));
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("getScheduledAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getScheduledAppointmetsByPatient/{patientId}
        public IActionResult GetScheduledAppointmentsByPatient(int patientId)
        {
            domainEventService.Save(new URLEvent("/api/Appointment/getScheduledAppointmetsByPatient/" + patientId, "GET"));
            List<AppointmentDto> result = new List<AppointmentDto>();
            appointmentService.GetScheduledAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment, doctorGateway.GetDoctorById(appointment.MedicalExamination.DoctorId))));
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("cancelAppointment/{appointmentId}")]       // GET /api/appointment/cancelAppointment/{appointmentId}
        public IActionResult CancelPatientAppointment(int appointmentId)
        {
            domainEventService.Save(new URLEvent("/api/Appointment/cancelAppointment/" + appointmentId, "PUT"));

            Appointment appointmentForCancelation = appointmentService.GetEntity(appointmentId);
            if (appointmentForCancelation == null)
            {
                return NotFound();
            }
            doctorWorkDayService.CancelPatientAppointment(appointmentForCancelation.DoctorWorkDayId, appointmentId, DateTime.Now);
            return Ok(appointmentService.CancelPatientAppointment(appointmentId, DateTime.Now));
        }

        [HttpGet("getAllRecommendedTerms")]       // GET /api/appointment/getAllRecommendedTerms
        public IActionResult GetAllRecommendedTerms([FromQuery(Name = "startDate")] string startDate, [FromQuery(Name = "endDate")] string endDate, [FromQuery(Name = "doctorId")] string doctorId, [FromQuery(Name = "priority")] string priority)
        {
            domainEventService.Save(new URLEvent("/api/Appointment/getAllRecommendedTerms", "GET"));

            try
            {
                Dictionary<int, List<Appointment>> availableAppointments = doctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture), DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture), Int32.Parse(doctorId), priority);
                return Ok(DoctorWorkDayMapper.CreateDoctorWorkDayDtos(doctorWorkDayService.GetDoctorWorkDaysByIds(availableAppointments.Keys.ToList()), availableAppointments, doctorGateway.GetDoctorById((Int32.Parse(doctorId)))));
            }
            catch
            {
                return BadRequest("The data which were entered are incorrect!");
            }
        }

        [HttpGet("filledSurveyForAppointment/{appointmentId}")]       // GET /api/appointment/filledSurveyForAppointment/{appointmentId}
        public IActionResult FilledSurveyForAppointment(int appointmentId)
        {
            domainEventService.Save(new URLEvent("/api/Appointment/filledSurveyForAppointment/" + appointmentId, "GET"));
            Appointment appointment = appointmentService.FilledSurveyForAppointment(appointmentId);
            return Ok();
        }

        [HttpGet("countCancelledAppointmentsForPatient/{patientId}")]       // GET /api/appointment/countCancelledAppointmentsForPatient/{patientId}
        public IActionResult GetAllRecommendedTerms(int patientId)
        {
            domainEventService.Save(new URLEvent("/api/Appointment/countCancelledAppointmentsForPatient/" + patientId, "GET"));
            return Ok(appointmentService.CountCancelledAppointmentsForPatient(patientId, DateTime.Now));
        }
    }
}

