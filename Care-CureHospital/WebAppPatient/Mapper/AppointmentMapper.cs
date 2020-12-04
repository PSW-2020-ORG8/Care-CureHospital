using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class AppointmentMapper
    {
        public static AppointmentDto AppointmentToAppointmentDto(Appointment appointment)
        {
            AppointmentDto dto = new AppointmentDto();
            dto.Id = appointment.Id;
            dto.Canceled = appointment.Canceled;
            dto.SurveyFilled = appointment.MedicalExamination.SurveyFilled;
            dto.Date = appointment.StartTime.ToString("dd.MM.yyyy.");
            dto.Period = appointment.StartTime.ToString("HH:mm") + " - " + appointment.EndTime.ToString("HH:mm");
            dto.DoctorFullName = appointment.MedicalExamination.Doctor.Name + " " + appointment.MedicalExamination.Doctor.Surname;
            dto.DoctorSpecialization = appointment.MedicalExamination.Doctor.Specialitation.SpecialitationForDoctor;
            dto.Room = appointment.MedicalExamination.Room.RoomId;
            dto.MedicalExaminationId = appointment.MedicalExaminationId;

            return dto;
        }
    }
}
