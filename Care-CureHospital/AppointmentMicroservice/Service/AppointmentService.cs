﻿using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Gateway.Interface;
using AppointmentMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentMicroservice.Service
{
    public class AppointmentService : IAppointmentService
    {
        public IAppointmentRepository appointmentRepository;
        public IPatientGateway patientGateway;

        public AppointmentService(IAppointmentRepository appointmentRepository, IPatientGateway patientGateway)
        {
            this.appointmentRepository = appointmentRepository;
            this.patientGateway = patientGateway;
        }

        public List<Appointment> GetAllCancelledAppointmentsByPatient(int patientId)
        {
            return GetAllAppointmentsByPatient(patientId).ToList().Where(appointment => appointment.Canceled == true).ToList();
        }

        public List<Appointment> GetPreviousAppointmetsByPatient(int patientId, DateTime currentDate)
        {
            return GetAllAppointmentsByPatient(patientId).Where(appointment => appointment.EndTime < currentDate && appointment.Canceled == false).ToList();
        }

        public List<Appointment> GetScheduledAppointmetsByPatient(int patientId, DateTime currentDate)
        {
            return GetAllAppointmentsByPatient(patientId).Where(appointment => appointment.StartTime > currentDate && appointment.Canceled == false).ToList();
        }

        public List<Appointment> GetAllAppointmentsByPatient(int patientId)
        {
            return GetAllEntities().ToList().Where(appointment => appointment.MedicalExamination.PatientId == patientId).ToList();
        }

        public Appointment CancelPatientAppointment(int appointmentId, DateTime today)
        {
            Appointment appointmentForCancelation = GetEntity(appointmentId);
            if (today < appointmentForCancelation.StartTime.AddHours(-48))
            {
                appointmentForCancelation.Canceled = true;
                appointmentForCancelation.CancellationDate = today;
                UpdateEntity(appointmentForCancelation);
                SetIfPatientMalicious(appointmentForCancelation.MedicalExamination.PatientId, today);
                return appointmentForCancelation;
            }
            return null;
        }

        /// <summary> This metod sets patient as malicious if patient canceled three or more appointments in last 30 days </summary>
        public void SetIfPatientMalicious(int patientId, DateTime today)
        {
            if (CountCancelledAppointmentsForPatient(patientId, today) >= 3)
            {
                 patientGateway.SetMaliciousPatient(patientId);
            }
        }

        public int CountCancelledAppointmentsForPatient(int patientId, DateTime currentCancellationDate)
        {
            List<Appointment> cancelledAppointments = GetAllCancelledAppointmentsByPatient(patientId);
            List<Appointment> result = new List<Appointment>();
            foreach (Appointment cancelledAppointment in cancelledAppointments)
            {
                if (currentCancellationDate >= cancelledAppointment.CancellationDate && currentCancellationDate.AddDays(-30) <= cancelledAppointment.CancellationDate)
                {
                    result.Add(cancelledAppointment);
                }
            }
            return result.Count;
        }

        public Appointment FilledSurveyForAppointment(int appointmentId)
        {
            Appointment appointment = GetEntity(appointmentId);
            appointment.MedicalExamination.SurveyFilled = true;
            UpdateEntity(appointment);
            return appointment;
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
    }
}

