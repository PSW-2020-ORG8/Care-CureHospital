﻿using EPrescriptionMicroservice.Domain;
using EPrescriptionMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPrescriptionMicroservice.Service
{
    public class EPrescriptionService : IEPrescriptionService
    {
        public IEPrescriptionRepository eprescriptionRepository;
        public ISftpService sftpService;

        public static object Assert { get; set; }

        public EPrescriptionService(IEPrescriptionRepository eprescriptionRepository)
        {
            this.eprescriptionRepository = eprescriptionRepository;
        }

        public EPrescriptionService(IEPrescriptionRepository eprescriptionRepository, ISftpService sftpService)
        {
            this.eprescriptionRepository = eprescriptionRepository;
            this.sftpService = sftpService;
        }

        public EPrescription AddEntity(EPrescription entity)
        {
            return eprescriptionRepository.AddEntity(entity);
        }

        public void DeleteEntity(EPrescription entity)
        {
            eprescriptionRepository.DeleteEntity(entity);
        }

        public IEnumerable<EPrescription> GetAllEntities()
        {
            return eprescriptionRepository.GetAllEntities();
        }

        public EPrescription GetEntity(int id)
        {
            return eprescriptionRepository.GetEntity(id);
        }
        public void UpdateEntity(EPrescription entity)
        {
            eprescriptionRepository.UpdateEntity(entity);
        }

        public EPrescription GetEPrescriptionForPatient(int patientID)
        {
            return eprescriptionRepository.GetAllEntities().ToList().Find(ePrescription => ePrescription.PatientId == patientID);
        }

        public List<EPrescription> GetEPrescriptionsForPatient(int patientID)
        {
            List<EPrescription> eprescriptionsForPatient = new List<EPrescription>();
            foreach (EPrescription eprescription in eprescriptionRepository.GetAllEntities().ToList())
            {
                if (eprescription.PatientId == patientID)
                {
                    eprescriptionsForPatient.Add(eprescription);
                }
            }
            return eprescriptionsForPatient;
        }

        public List<EPrescription> FindEPrescriptionsForCommentParameter(int patientID, string comment)
        {
            List<EPrescription> searchResult = new List<EPrescription>();
            foreach (EPrescription eprescription in GetEPrescriptionsForPatient(patientID))
            {
                if ((eprescription.Comment.ToString().ToLower().Contains(comment.ToLower())))
                {
                    searchResult.Add(eprescription);
                }
            }
            return searchResult;
        }

        public List<EPrescription> FindEPrescriptionsForDateParameter(int patientID, string publishingDate)
        {
            List<EPrescription> searchResult = new List<EPrescription>();
            foreach (EPrescription eprescription in GetEPrescriptionsForPatient(patientID))
            {
                if ((eprescription.PublishingDate.ToString("yyyy-MM-dd").Equals(publishingDate)))
                {
                    searchResult.Add(eprescription);
                }
            }
            return searchResult;
        }

        public void SendPrescriptionSftp()
        {
            String prescriptionFile = "Files\\Prescription_" + DateTime.Now.ToString("dd-MM-yyyy") + ".json";
            System.IO.File.WriteAllText(prescriptionFile, "EPrescription:");
            try
            {
                sftpService.UploadFile(prescriptionFile);
            }
            catch (Exception e)
            {
                throw new Exception("The file can not be uploaded, because there where errors on the server side. Please try again later!", e);
            }
        }
    }
}