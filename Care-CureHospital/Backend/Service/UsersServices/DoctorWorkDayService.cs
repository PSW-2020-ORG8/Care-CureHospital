using Backend.Repository.UsersRepository;
using Model.Term;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersServices
{
    public class DoctorWorkDayService : IService<DoctorWorkDay, int>
    {
        IDoctorWorkDayRepository doctorWorkDayRepository;

        public DoctorWorkDayService(IDoctorWorkDayRepository doctorWorkDayRepository)
        {
            this.doctorWorkDayRepository = doctorWorkDayRepository;
        }
        public DoctorWorkDay AddEntity(DoctorWorkDay entity)
        {
            return doctorWorkDayRepository.AddEntity(entity);
        }

        public void DeleteEntity(DoctorWorkDay entity)
        {
            doctorWorkDayRepository.DeleteEntity(entity);
        }

        public IEnumerable<DoctorWorkDay> GetAllEntities()
        {
            return doctorWorkDayRepository.GetAllEntities();
        }

        public DoctorWorkDay GetEntity(int id)
        {
            return doctorWorkDayRepository.GetEntity(id);
        }

        public void UpdateEntity(DoctorWorkDay entity)
        {
            doctorWorkDayRepository.UpdateEntity(entity);
        }

        public DoctorWorkDay GetDoctorWorkDayByDateAndDoctorId(DateTime date, int doctorId)
        {
            return doctorWorkDayRepository.GetAllEntities().FirstOrDefault(doctorWorkDay => DateTime.Compare(doctorWorkDay.Date, date) == 0 && doctorWorkDay.DoctorId == doctorId);
        }

        public List<Appointment> GetAvailableAppointmentsByDateAndDoctorId(DateTime date, int doctorId)
        {
            List<Appointment> result = InitializeAvailableApoointmentsList(date);
            foreach(Appointment scheduledAppointment in GetDoctorWorkDayByDateAndDoctorId(date, doctorId).ScheduledAppointments)
            {
                var appointment = result.Find(o => DateTime.Compare(o.StartTime, scheduledAppointment.StartTime) == 0);
                if (appointment != null || scheduledAppointment.Canceled == false)
                {
                    result.Remove(appointment);
                }
            }
            return result;
        }

        public List<Appointment> InitializeAvailableApoointmentsList(DateTime date)
        {
            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
            List<Appointment> result = new List<Appointment>();
            for (int i = 0; i < 24; i++)
            {
                Appointment appointmentTimePeriod = new Appointment { StartTime = startTime.AddMinutes(30 * i), EndTime = startTime.AddMinutes(30 * (i + 1)), Canceled = false };
                result.Add(appointmentTimePeriod);
            }
            return result;
        }
    }
}
