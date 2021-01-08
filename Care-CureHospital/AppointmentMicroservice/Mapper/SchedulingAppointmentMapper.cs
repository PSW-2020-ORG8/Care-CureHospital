using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Dto;


namespace AppointmentMicroservice.Mapper
{
    public class SchedulingAppointmentMapper
    {
        public static Appointment AppointmentDtoToAppointment(SchedulingAppointmentDto dto)
        {
            Appointment appointment = new Appointment();

            appointment.Canceled = dto.Canceled;
            appointment.DoctorWorkDayId = dto.DoctorWorkDayId;
            appointment.StartTime = dto.StartTime;
            appointment.EndTime = dto.EndTime;
            appointment.MedicalExamination = dto.MedicalExamination;

            return appointment;
        }
    }
}
