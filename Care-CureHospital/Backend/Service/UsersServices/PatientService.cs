using Backend.Repository.UsersRepository;
using Model.AllActors;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersServices
{
    public class PatientService : IService<Patient, int>
    {
        public IPatientRepository PatientRepository;

        public PatientService(IPatientRepository patientFeedbackRepository)
        {
            PatientRepository = patientFeedbackRepository;
        }

        public Patient AddEntity(Patient entity)
        {
            return PatientRepository.AddEntity(entity);
        }

        public void DeleteEntity(Patient entity)
        {
            PatientRepository.DeleteEntity(entity);
        }

        public IEnumerable<Patient> GetAllEntities()
        {
            return PatientRepository.GetAllEntities();
        }

        public Patient GetEntity(int id)
        {
            return PatientRepository.GetEntity(id);
        }

        public void UpdateEntity(Patient entity)
        {
            PatientRepository.UpdateEntity(entity);
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
