using AppointmentMicroservice.Domain;
using System;

namespace AppointmentMicroservice.Dto
{
    public class SchedulingAppointmentDto
    {
        public int Id { get; set; }
        public bool Canceled { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public MedicalExamination MedicalExamination { get; set; }
        public int DoctorWorkDayId { get; set; }

        public SchedulingAppointmentDto()
        {
        }
    }
}
