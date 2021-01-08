using AppointmentMicroservice.Domain;
using System;
using System.Collections.Generic;

namespace AppointmentMicroservice.Service
{
    public interface IDoctorWorkDayService : IService<DoctorWorkDay, int>
    {
        public DoctorWorkDay GetDoctorWorkDayByDateAndDoctorId(DateTime date, int doctorId);
        public List<Appointment> GetAvailableAppointmentsByDateAndDoctorId(DateTime date, int doctorId);
        public Dictionary<int, List<Appointment>> GetAvailableAppointmentsByDateAndSpecialization(DateTime date, int doctorSpecializationId);
        public List<Appointment> InitializeAvailableApoointmentsList(DateTime date);
        public Dictionary<int, List<Appointment>> GetAvailableAppointmentsByDateRangeAndDoctorId(DateTime startDate, DateTime endDate, int doctorId);
        public Dictionary<int, List<Appointment>> GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(DateTime startDate, DateTime endDate, int doctorId, string priority);
        public bool ScheduleAppointment(Appointment appointment);
        public List<DoctorWorkDay> GetDoctorWorkDaysByIds(List<int> ids);
        public int GetNumberOfAvailableAppointments(Dictionary<int, List<Appointment>> appointments);
        public void CancelPatientAppointment(int doctorWorkDayId, int appointmentId, DateTime today);
    }
}
