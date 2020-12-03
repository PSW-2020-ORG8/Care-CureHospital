using Backend.Repository.ExaminationSurgeryRepository;
using Model.Term;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class AppointmentService : IService<Appointment, int>
    {
        public IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public Appointment AddEntity(Appointment entity)
        {
            return appointmentRepository.AddEntity(entity);
        }

        public void DeleteEntity(Appointment entity)
        {
            appointmentRepository.DeleteEntity(entity);
        }

        public IEnumerable<Appointment> GetAllEntities()
        {
            return appointmentRepository.GetAllEntities();
        }

        public Appointment GetEntity(int id)
        {
            return appointmentRepository.GetEntity(id);
        }

        public void UpdateEntity(Appointment entity)
        {
            appointmentRepository.UpdateEntity(entity);
        }

        public List<Appointment> GetPreviousAppointmetsByPatient(int patientId, DateTime currentDate)
        {
            return GetAllAppointmentsByPatient(patientId).Where(appointment => appointment.EndTime < currentDate).ToList();
        }

        public List<Appointment> GetScheduledAppointmetsByPatient(int patientId, DateTime currentDate)
        {
            return GetAllAppointmentsByPatient(patientId).Where(appointment => appointment.StartTime > currentDate).ToList();
        }

        public List<Appointment> GetAllAppointmentsByPatient(int patientId)
        {
            return GetAllEntities().ToList().Where(appointment => appointment.MedicalExamination.PatientId == patientId).ToList();
        }
    }
}
