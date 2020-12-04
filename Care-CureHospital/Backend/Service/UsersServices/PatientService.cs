﻿using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Repository.UsersRepository;
using Backend.Service.ExaminationSurgeryServices;
using Model.AllActors;
using Model.Term;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersServices
{
    public class PatientService : IService<Patient, int>
    {
        public IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public Patient BlockMaliciousPatient(int patientId)
        {
            Patient maliciousPatient = GetEntity(patientId);
            maliciousPatient.Blocked = true;
            UpdateEntity(maliciousPatient);
            return maliciousPatient;
        }

        //public void SetIfPatientMalicious(int patientId)
        //{
        //    if (IsPatientMalicious(patientId, DateTime.Today))
        //    {
        //        Patient maliciousPatient = GetEntity(patientId);
        //        maliciousPatient.Malicious = true;
        //        UpdateEntity(maliciousPatient);
        //    }
        //}

        //public bool IsPatientMalicious(int patientId, DateTime currentCancellationDate)
        //{
        //    List<Appointment> cancelledAppointments = appointmentService.getAllCancelledAppointmentsByPatient(patientId);
        //    List<Appointment> result = new List<Appointment>();
        //    foreach (Appointment cancelledAppointment in cancelledAppointments)
        //    {
        //        if (currentCancellationDate > cancelledAppointment.CancellationDate && currentCancellationDate.AddDays(-30) < cancelledAppointment.CancellationDate)
        //        {
        //            result.Add(cancelledAppointment);
        //        }
        //    }
        //    return result.Count >= 3;
        //}

        public List<Patient> GetMaliciousPatients()
        {
            return GetAllEntities().ToList().Where(patient => patient.Malicious == true).ToList();
        }

        public Patient AddEntity(Patient entity)
        {
            return patientRepository.AddEntity(entity);
        }

        public void DeleteEntity(Patient entity)
        {
            patientRepository.DeleteEntity(entity);
        }

        public IEnumerable<Patient> GetAllEntities()
        {
            return patientRepository.GetAllEntities();
        }

        public Patient GetEntity(int id)
        {
            return patientRepository.GetEntity(id);
        }

        public Patient GetUserByUsername(string username)
        {
            return patientRepository.GetPatientByUsername(username);
        }

        public void UpdateEntity(Patient entity)
        {
            patientRepository.UpdateEntity(entity);
        }

        public bool DoesUsernameExist(string username)
        {
            foreach (Patient patient in GetAllEntities())
                if (patient.Username.Equals(username))
                    return true;
            return false;
        }
    }
}
