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
                if ((report.Comment.ToString().ToLower().Contains(comment.ToLower())))
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
                if ((report.PublishingDate.ToString("yyyy-MM-dd").Equals(publishingDate)))
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
                if (doctorFullName.Contains(report.MedicalExamination.Doctor.Name.ToString()) || doctorFullName.Contains(report.MedicalExamination.Doctor.Surname.ToString()))
                {
                    searchResult.Add(report);
                }
            }
            return searchResult;
        }

        public List<MedicalExaminationReport> FindReportsUsingAdvancedSearch(int patientId, Dictionary<string, string> searchParameters, List<string> logicOperators)
        {
            List<MedicalExaminationReport> currentResult = FindReportsBySearchParameter(patientId, searchParameters.Keys.ToList()[0], searchParameters.Values.ToList()[0]);
            for(int i = 1; i < searchParameters.Keys.Count; i++)
            {
                List<MedicalExaminationReport> nextResult = FindReportsBySearchParameter(patientId, searchParameters.Keys.ToList()[i], searchParameters.Values.ToList()[i]);
                currentResult = CalculateLogicalOperationResult(logicOperators[i - 1], currentResult, nextResult);
            }
            return currentResult;          
        }

        public List<MedicalExaminationReport> FindReportsBySearchParameter(int patientId, string searchParameter, string parameterValue)
        {
            if (searchParameter.Equals("Doktoru"))
            {
                return FindReportsForDoctorParameter(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Datumu"))
            {
                return FindReportsForDateParameter(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Sadržaju"))
            {
                return FindReportsForCommentParameter(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Sobi"))
            {
                return FindReportsForRoomParameter(patientId, parameterValue);
            }
            return null;
        }

        public List<MedicalExaminationReport> CalculateLogicalOperationResult(string logicOperator, List<MedicalExaminationReport> firstResult, List<MedicalExaminationReport> secondResult)
        {
            List<MedicalExaminationReport> result = new List<MedicalExaminationReport>();
            if (logicOperator.Equals("I"))
            {
                result = firstResult.Intersect(secondResult).ToList();
            } 
            else if (logicOperator.Equals("ILI"))
            {
                result = firstResult.Union(secondResult).ToList();
            }
            return result;
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
