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
        DoctorService doctorService;

        public DoctorWorkDayService(IDoctorWorkDayRepository doctorWorkDayRepository, DoctorService doctorService)
        {
            this.doctorWorkDayRepository = doctorWorkDayRepository;
            this.doctorService = doctorService;
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

        public List<DoctorWorkDay> GetDoctorWorkDayByDateAndDoctorSpecialization(DateTime date, string doctorSpecialization)
        {
            return doctorWorkDayRepository.GetAllEntities().Where(doctorWorkDay => DateTime.Compare(doctorWorkDay.Date, date) == 0 && doctorWorkDay.Doctor.Specialitation.SpecialitationForDoctor.Equals(doctorSpecialization)).ToList();
        }

        public List<Appointment> GetAvailableAppointmentsByDateAndDoctorId(DateTime date, int doctorId)
        {
            List<Appointment> result = new List<Appointment>();
            if(GetDoctorWorkDayByDateAndDoctorId(date, doctorId) != null) 
            {
                result = InitializeAvailableApoointmentsList(date);
                foreach (Appointment scheduledAppointment in GetDoctorWorkDayByDateAndDoctorId(date, doctorId).ScheduledAppointments)
                {
                    var appointment = result.Find(o => DateTime.Compare(o.StartTime, scheduledAppointment.StartTime) == 0);
                    if (appointment != null && scheduledAppointment.Canceled == false)
                    {
                        result.Remove(appointment);
                    }
                }
            }
            return result;
        }

        public List<Appointment> GetAvailableAppointmentsByDateAndSpecialization(DateTime date, string doctorSpecialization)
        {
            List<Appointment> result = new List<Appointment>();
            if (GetDoctorWorkDayByDateAndDoctorSpecialization(date, doctorSpecialization).Count != 0)
            {
                foreach(DoctorWorkDay doctorWorkDay in GetDoctorWorkDayByDateAndDoctorSpecialization(date, doctorSpecialization))
                {
                    result.AddRange(GetAvailableAppointmentsByDateAndDoctorId(date, doctorWorkDay.DoctorId));
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

        public List<Appointment> GetAvailableAppointmentsByDateRangeAndDoctorId(DateTime startDate, DateTime endDate, int doctorId)
        {
            List<Appointment> result = new List<Appointment>();
            for (DateTime date = startDate; DateTime.Compare(date, endDate) <= 0; date = date.AddDays(1))
            {
                result.AddRange(GetAvailableAppointmentsByDateAndDoctorId(date, doctorId));
            }
            return result;
        }

        public List<Appointment> GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(DateTime startDate, DateTime endDate, int doctorId, string priority)
        {
            List<Appointment> result = GetAvailableAppointmentsByDateRangeAndDoctorId(startDate, endDate, doctorId);           
            if (priority.Equals("Vremenski period"))
            {      
                if (result.Count == 0)
                {
                    string doctorSpecialization = doctorService.GetEntity(doctorId).Specialitation.SpecialitationForDoctor;
                    result = GetAvailableAppointmentsForOtherDoctors(startDate, endDate, doctorSpecialization);
                }
            } else if (priority.Equals("Doktor"))
            {
                if (result.Count == 0)
                {
                    result = GetAvailableAppointmentsByExpandDateRange(startDate, endDate, doctorId);
                }
            }
            return result;
        }

        private List<Appointment> GetAvailableAppointmentsForOtherDoctors(DateTime startDate, DateTime endDate, string doctorSpecialization)
        {
            List<Appointment> result = new List<Appointment>();
            for (DateTime date = startDate; DateTime.Compare(date, endDate) <= 0; date = date.AddDays(1))
            {
                result.AddRange(GetAvailableAppointmentsByDateAndSpecialization(date, doctorSpecialization));
            }
            return result;
        }

        private List<Appointment> GetAvailableAppointmentsByExpandDateRange(DateTime startDate, DateTime endDate, int doctorId)
        {
            List<Appointment> result = ExpandeDateRange(startDate, endDate, doctorId);
            int numberOfExpandingIteration = 0;
            while (result.Count == 0)
            {
                if (++numberOfExpandingIteration > 6)
                {
                    break;
                }
                result = ExpandeDateRange(startDate, endDate, doctorId);
            }
            return result;
        }

        private List<Appointment> ExpandeDateRange(DateTime startDate, DateTime endDate, int doctorId)
        {
            DateTime newStartDate = startDate.AddDays(-1);
            if (DateTime.Compare(newStartDate, DateTime.Today) < 0)
            {
                newStartDate = DateTime.Today;
            }
            return GetAvailableAppointmentsByDateRangeAndDoctorId(newStartDate, endDate.AddDays(1), doctorId);
        }
    }
}
