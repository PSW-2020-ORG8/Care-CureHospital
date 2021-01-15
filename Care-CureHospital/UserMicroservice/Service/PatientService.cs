﻿using System.Collections.Generic;
using System.Linq;
using UserMicroservice.Domain;
using UserMicroservice.Repository;

namespace UserMicroservice.Service
{
    public class PatientService : IPatientService
    {
        public IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public Patient BlockMaliciousPatient(int patientId)
        {
            Patient maliciousPatient = GetEntity(patientId);
            maliciousPatient.PatientStatus.Blocked = true;
            UpdateEntity(maliciousPatient);
            return maliciousPatient;
        }

        public Patient SetMaliciousPatient(int patientId)
        {
            Patient patient = GetEntity(patientId);
            patient.PatientStatus.Malicious = true;
            UpdateEntity(patient);
            return patient;
        }

        public List<Patient> GetMaliciousPatients()
        {
            return GetAllEntities().ToList().Where(patient => patient.PatientStatus.Malicious == true).ToList();
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

        public Patient GetPatientByUsername(string username)
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
                if (patient.CheckUser(username))
                    return true;
            return false;
        }
    }
}
