using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Dto;
using System;

namespace AppointmentMicroservice.Mapper
{
    public class AppointmentMapper
    {
        public static Appointment AppointmentDtoToAppointment(AppointmentDto dto)
        {
            Appointment appointment = new Appointment();
            appointment.Id = dto.Id;
            appointment.Canceled = dto.Canceled;
            appointment.CancellationDate = DateTime.Parse(dto.CancellationDate);
            appointment.MedicalExamination.SurveyFilled = dto.SurveyFilled;
            appointment.StartTime = DateTime.Parse(dto.Date);
            return appointment;
        }

        public static AppointmentDto AppointmentToAppointmentDto(Appointment appointment, Doctor doctor)
        {
            AppointmentDto dto = new AppointmentDto();
            dto.Id = appointment.Id;
            dto.Canceled = appointment.Canceled;
            dto.SurveyFilled = appointment.MedicalExamination.SurveyFilled;
            dto.Date = appointment.StartTime.ToString("dd.MM.yyyy.");
            dto.Period = appointment.StartTime.ToString("HH:mm") + " - " + appointment.EndTime.ToString("HH:mm");
            dto.DoctorFullName = doctor.Name + " " + doctor.Surname;
            dto.DoctorSpecialization = doctor.Specialitation.SpecialitationForDoctor;
            dto.Room = appointment.MedicalExamination.Room.RoomId;
            dto.MedicalExaminationId = appointment.MedicalExaminationId;
            dto.DoctorId = appointment.MedicalExamination.DoctorId;

            return dto;
        }
    }
}
