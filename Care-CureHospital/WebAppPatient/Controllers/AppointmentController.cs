using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppPatient.Mapper;

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
            return Ok(DoctorWorkDayMapper.DoctorWorkDayToDoctorWorkDayDto(
                App.Instance().DoctorWorkDayService.GetDoctorWorkDayByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-dd-MM", CultureInfo.InvariantCulture), doctorId),
                App.Instance().DoctorWorkDayService.GetAvailableAppointmentsByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-dd-MM", CultureInfo.InvariantCulture), doctorId)
                ));
        }

    }
}
