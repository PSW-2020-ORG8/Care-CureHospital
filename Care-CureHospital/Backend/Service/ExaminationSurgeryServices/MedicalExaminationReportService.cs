using Backend.Model.PatientDoctor;
using Backend.Repository.ExaminationSurgeryRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class MedicalExaminationReportService : IService<MedicalExaminationReport, int>
    {
        public IMedicalExaminationReportRepository medicalExaminationReportRepository;

        public MedicalExaminationReportService(IMedicalExaminationReportRepository medicalExaminationReportRepository)
        {
            this.medicalExaminationReportRepository = medicalExaminationReportRepository;
        }

        public MedicalExaminationReport GetEntity(int id)
        {
            return medicalExaminationReportRepository.GetEntity(id);
        }

        public IEnumerable<MedicalExaminationReport> GetAllEntities()
        {
            return medicalExaminationReportRepository.GetAllEntities();
        }

        public MedicalExaminationReport AddEntity(MedicalExaminationReport entity)
        {
            return medicalExaminationReportRepository.AddEntity(entity);
        }

        public void UpdateEntity(MedicalExaminationReport entity)
        {
            medicalExaminationReportRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(MedicalExaminationReport entity)
        {
            medicalExaminationReportRepository.DeleteEntity(entity);
        }
    }
}
