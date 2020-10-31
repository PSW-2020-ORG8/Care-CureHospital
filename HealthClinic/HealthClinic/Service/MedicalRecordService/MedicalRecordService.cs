/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Model.PatientDoctor;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;

namespace Service.MedicalRecordService
{
    public class MedicalRecordService : IService<MedicalRecord, int>
    {
        public IMedicalRecordRepository medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public Model.PatientDoctor.MedicalRecord OpenMedicalRecord(Model.PatientDoctor.MedicalRecord medicalRecord)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetMedicalRecordByPatient(Model.AllActors.Patient patient)
        {
            return medicalRecordRepository.GetMedicalRecordByPatient(patient);
        }

        public MedicalRecord GetEntity(int id)
        {
            return medicalRecordRepository.GetEntity(id);
        }

        public IEnumerable<MedicalRecord> GetAllEntities()
        {
            return medicalRecordRepository.GetAllEntities();
        }

        public MedicalRecord AddEntity(MedicalRecord entity)
        {
            return medicalRecordRepository.AddEntity(entity);
        }

        public void UpdateEntity(MedicalRecord entity)
        {
            medicalRecordRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(MedicalRecord entity)
        {
            medicalRecordRepository.DeleteEntity(entity);
        }
    }
}