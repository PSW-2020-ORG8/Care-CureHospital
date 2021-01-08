using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Dto;
using System.Collections.Generic;

namespace AppointmentMicroservice.Mapper
{
    public class DoctorWorkDayMapper
    {
        public static DoctorWorkDayDto DoctorWorkDayToDoctorWorkDayDto(DoctorWorkDay doctorWorkDay, List<Appointment> availableAppointments, Doctor doctor)
        {
            DoctorWorkDayDto dto = null;

            if (doctorWorkDay != null)
            {
                dto = new DoctorWorkDayDto();

                dto.Id = doctorWorkDay.Id;
                dto.DoctorId = doctorWorkDay.DoctorId;
                dto.RoomId = doctorWorkDay.RoomId;
                dto.AvailableAppointments = availableAppointments;
                dto.Specialization = doctor.Specialitation.SpecialitationForDoctor;
                dto.DoctorFullName = "Dr " + doctor.Name + " " + doctor.Surname;
            }

            return dto;
        }

        public static List<DoctorWorkDayDto> CreateDoctorWorkDayDtos(List<DoctorWorkDay> doctorWorkDays, Dictionary<int, List<Appointment>> availableAppointments, Doctor doctor)
        {
            List<DoctorWorkDayDto> result = new List<DoctorWorkDayDto>();
            foreach (DoctorWorkDay doctorWorkDay in doctorWorkDays)
            {
                result.Add(DoctorWorkDayToDoctorWorkDayDto(doctorWorkDay, availableAppointments[doctorWorkDay.Id], doctor));
            }
            return result;
        }
    }
}
