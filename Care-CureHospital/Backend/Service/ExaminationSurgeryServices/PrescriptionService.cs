using Backend.Model.PatientDoctor;
using Backend.Repository.ExaminationSurgeryRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class PrescriptionService : IService<Prescription, int>
    {
        public IPrescriptionRepository prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        public Prescription GetEntity(int id)
        {
            return prescriptionRepository.GetEntity(id);
        }

        public IEnumerable<Prescription> GetAllEntities()
        {
            return prescriptionRepository.GetAllEntities();
        }

        public Prescription AddEntity(Prescription entity)
        {
            return prescriptionRepository.AddEntity(entity);
        }

        public void UpdateEntity(Prescription entity)
        {
            prescriptionRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Prescription entity)
        {
            prescriptionRepository.DeleteEntity(entity);
        }
    }
}
