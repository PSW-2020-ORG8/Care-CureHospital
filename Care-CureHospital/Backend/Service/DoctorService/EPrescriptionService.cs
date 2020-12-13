using Backend.Model.PatientDoctor;
using Backend.Repository.DoctorRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.DoctorService
{
    public class EPrescriptionService : IService<EPrescription, int>
    {
        public IEPrescriptionRepository eprescriptionRepository;

        public static object Assert { get; set; }

        public EPrescriptionService(IEPrescriptionRepository eprescriptionRepository)
        {
            this.eprescriptionRepository = eprescriptionRepository;
        }

        public EPrescription AddEntity(EPrescription entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(EPrescription entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EPrescription> GetAllEntities()
        {
            return eprescriptionRepository.GetAllEntities();
        }

        public EPrescription GetEntity(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateEntity(EPrescription entity)
        {
            throw new NotImplementedException();
        }

        public EPrescription GetEPrescriptionForPatient(int patientID)
        {
            return eprescriptionRepository.GetAllEntities().ToList().Find(ePrescription => ePrescription.PatientId == patientID);
        }
    }
}
