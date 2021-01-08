using AppointmentMicroservice.Domain;
using System;
using System.Collections.Generic;

namespace AppointmentMicroservice.Dto
{
    public class DoctorWorkDayDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public string Specialization { get; set; }
        public string DoctorFullName { get; set; }

        public List<Appointment> AvailableAppointments { get; set; }

    }
}
