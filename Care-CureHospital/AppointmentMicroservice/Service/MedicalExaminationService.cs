using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Service
{
    public class MedicalExaminationService : IService<MedicalExamination, int>
    {
        public IMedicalExaminationRepository medicalExaminationRepository;

        public MedicalExaminationService(IMedicalExaminationRepository medicalExaminationRepository)
        {
            this.medicalExaminationRepository = medicalExaminationRepository;
        }

        public List<MedicalExamination> GetByDate(DateTime date)
        {
            List<MedicalExamination> medicalExaminations = new List<MedicalExamination>();
            foreach (MedicalExamination m in medicalExaminationRepository.GetAllEntities())
            {
                if (m.FromDateTime.Equals(date))
                {
                    medicalExaminations.Add(m);
                }
            }

            return medicalExaminations;
        }

        public MedicalExamination GetEntity(int id)
        {
            return medicalExaminationRepository.GetEntity(id);
        }

        public IEnumerable<MedicalExamination> GetAllEntities()
        {
            return medicalExaminationRepository.GetAllEntities();
        }

        public MedicalExamination AddEntity(MedicalExamination entity)
        {
            return medicalExaminationRepository.AddEntity(entity);
        }

        public void UpdateEntity(MedicalExamination entity)
        {
            medicalExaminationRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(MedicalExamination entity)
        {
            medicalExaminationRepository.DeleteEntity(entity);
        }

    }
}