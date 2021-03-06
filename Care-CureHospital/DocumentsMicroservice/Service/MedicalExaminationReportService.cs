﻿using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Gateway.Interface;
using DocumentsMicroservice.Repository;
using System.Collections.Generic;
using System.Linq;

namespace DocumentsMicroservice.Service
{
    public class MedicalExaminationReportService : IMedicalExaminationReportService
    {
        public IMedicalExaminationReportRepository medicalExaminationReportRepository;
        public IMedicalExaminationGateway medicalExaminationGateway;

        public MedicalExaminationReportService(IMedicalExaminationReportRepository medicalExaminationReportRepository, IMedicalExaminationGateway medicalExaminationGateway)
        {
            this.medicalExaminationReportRepository = medicalExaminationReportRepository;
            this.medicalExaminationGateway = medicalExaminationGateway;
        }

        public List<MedicalExaminationReport> GetMedicalExaminationReportsForPatient(int patientID)
        {
            List<MedicalExaminationReport> medicalExaminationReportsForPatient = new List<MedicalExaminationReport>();
            MedicalExamination medicalExamination = null;
            foreach (MedicalExaminationReport report in medicalExaminationReportRepository.GetAllEntities().ToList())
            {
                medicalExamination = medicalExaminationGateway.GetMedicalExaminationById(report.MedicalExaminationId);
                if (medicalExamination.Patient.Id == patientID)
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
                MedicalExamination medicalExamination = medicalExaminationGateway.GetMedicalExaminationById(report.MedicalExaminationId);
                if (medicalExamination.Room.RoomId.Equals(numberOfRoom))
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
                MedicalExamination medicalExamination = medicalExaminationGateway.GetMedicalExaminationById(report.MedicalExaminationId);
                if (doctorFullName.Contains(medicalExamination.Doctor.Name.ToString()) || doctorFullName.Contains(medicalExamination.Doctor.Surname.ToString()))
                {
                    searchResult.Add(report);
                }
            }
            return searchResult;
        }

        /// <summary> This method finds reports with maximum four search parameters and logical operator (and, or) between them. </summary>
        public List<MedicalExaminationReport> FindReportsUsingAdvancedSearch(int patientId, Dictionary<string, string> searchParameters, List<string> logicOperators)
        {
            List<MedicalExaminationReport> currentResult = FindReportsBySearchParameter(patientId, searchParameters.Keys.ToList()[0], searchParameters.Values.ToList()[0]);
            for (int i = 1; i < searchParameters.Keys.Count; i++)
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
                return FindReportsByDoctorUsingSimpleSearch(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Datumu"))
            {
                return FindReportsByDateUsingSimpleSearch(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Sadržaju"))
            {
                return FindReportsByCommentUsingSimpleSearch(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Sobi"))
            {
                return FindReportsByRoomUsingSimpleSearch(patientId, parameterValue);
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

        /// <summary> This method finds reports with maximum four search parameters. </summary>
        public List<MedicalExaminationReport> FindReportsUsingSimpleSearch(int patientId, string doctor, string date, string comment, string room)
        {
            return IntersectionOfSimpleSearchReportsResults(FindReportsByDoctorUsingSimpleSearch(patientId, doctor), FindReportsByDateUsingSimpleSearch(patientId, date),
                FindReportsByCommentUsingSimpleSearch(patientId, comment), FindReportsByRoomUsingSimpleSearch(patientId, room));
        }

        public List<MedicalExaminationReport> IntersectionOfSimpleSearchReportsResults(List<MedicalExaminationReport> reportsByDoctor, List<MedicalExaminationReport> reportsByDate, List<MedicalExaminationReport> reportsByComment, List<MedicalExaminationReport> reportsByRoom)
        {
            List<MedicalExaminationReport> result = reportsByDoctor.Intersect(reportsByDate).ToList();
            result = result.Intersect(reportsByComment).ToList();
            result = result.Intersect(reportsByRoom).ToList();

            return result;
        }

        public List<MedicalExaminationReport> FindReportsByDoctorUsingSimpleSearch(int patientId, string doctor)
        {
            if (doctor == null || doctor.Equals(""))
            {
                return GetMedicalExaminationReportsForPatient(patientId).ToList();
            }
            else
            {
                return FindReportsForDoctorParameter(patientId, doctor);
            }
        }

        public List<MedicalExaminationReport> FindReportsByDateUsingSimpleSearch(int patientId, string date)
        {
            if (date == null || date.Equals(""))
            {
                return GetMedicalExaminationReportsForPatient(patientId).ToList();
            }
            else
            {
                return FindReportsForDateParameter(patientId, date);
            }
        }

        public List<MedicalExaminationReport> FindReportsByCommentUsingSimpleSearch(int patientId, string comment)
        {
            if (comment == null || comment.Equals(""))
            {
                return GetMedicalExaminationReportsForPatient(patientId).ToList();
            }
            else
            {
                return FindReportsForCommentParameter(patientId, comment);
            }
        }

        public List<MedicalExaminationReport> FindReportsByRoomUsingSimpleSearch(int patientId, string room)
        {
            if (room == null || room.Equals(""))
            {
                return GetMedicalExaminationReportsForPatient(patientId).ToList();
            }
            else
            {
                return FindReportsForRoomParameter(patientId, room);
            }
        }

        public MedicalExaminationReport GetMedicalExaminationReportByMedicalExaminationId(int medicalExaminationId)
        {
            return GetAllEntities().FirstOrDefault(o => o.MedicalExaminationId == medicalExaminationId);
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
