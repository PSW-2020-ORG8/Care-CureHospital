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

        public List<MedicalExaminationReport> GetMedicalExaminationReportsForPatient(int patientID)
        {
            List<MedicalExaminationReport> medicalExaminationReportsForPatient = new List<MedicalExaminationReport>();
            foreach (MedicalExaminationReport report in medicalExaminationReportRepository.GetAllEntities().ToList())
            {
                if (report.MedicalExamination.PatientId == patientID)
                {
                    medicalExaminationReportsForPatient.Add(report);
                }
            }
            return medicalExaminationReportsForPatient;
        }

        public List<MedicalExaminationReport> FindReportsForCommentParameter(int patientID, string comment)
        {
            List<MedicalExaminationReport> searchResult = new List<MedicalExaminationReport>();
            foreach (MedicalExaminationReport report in GetMedicalExaminationReportsForPatient(patientID))
            {
                if ((report.Comment.ToString().Contains(comment)))
                {
                    searchResult.Add(report);
                }
            }
            return searchResult;
        }

        public List<MedicalExaminationReport> FindReportsForDateParameter(int patientID, string publishingDate)
        {
            List<MedicalExaminationReport> searchResult = new List<MedicalExaminationReport>();
            foreach (MedicalExaminationReport report in GetMedicalExaminationReportsForPatient(patientID))
            {
                if ((report.PublishingDate.ToString("dd.MM.yyyy.").Equals(publishingDate)))
                {
                    searchResult.Add(report);
                }
            }
            return searchResult;
        }

        public List<MedicalExaminationReport> FindReportsForRoomParameter(int patientID, string numberOfRoom)
        {
            List<MedicalExaminationReport> searchResult = new List<MedicalExaminationReport>();
            foreach (MedicalExaminationReport report in GetMedicalExaminationReportsForPatient(patientID))
            {
                if ((report.MedicalExamination.Room.RoomId.Equals(numberOfRoom)))
                {
                    searchResult.Add(report);
                }
            }
            return searchResult;
        }

        public List<MedicalExaminationReport> FindReportsForDoctorParameter(int patientID, string doctorFullName)
        {
            List<MedicalExaminationReport> searchResult = new List<MedicalExaminationReport>();
            foreach (MedicalExaminationReport report in GetMedicalExaminationReportsForPatient(patientID))
            {
                if ((report.MedicalExamination.Doctor.Name.ToString() + " " + report.MedicalExamination.Doctor.Surname.ToString()).Equals(doctorFullName) ||
                    doctorFullName.Contains(report.MedicalExamination.Doctor.Name.ToString()) || doctorFullName.Contains(report.MedicalExamination.Doctor.Surname.ToString()))
                {
                    searchResult.Add(report);
                }
            }
            return searchResult;
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
