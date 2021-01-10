﻿using System;
using System.Collections.Generic;
using System.Linq;
using TenderMicroservice.Domain;
using TenderMicroservice.Repository;

namespace TenderMicroservice.Service
{
    public class TenderService : ITenderService
    {
        public ITenderRepository tenderRepository;
        public EmailService emailService;

        public TenderService(ITenderRepository tenderRepository)
        {
            this.tenderRepository = tenderRepository;
        }

        public TenderService(ITenderRepository tenderRepository, EmailService emailService)
        {
            this.tenderRepository = tenderRepository;
            this.emailService = emailService;
        }

        public IEnumerable<Tender> GetActiveTenders()
        {
            return tenderRepository.GetAllEntities().Where(activeTender => activeTender.Active.Equals(true));
        }

        public IEnumerable<Tender> GetInactiveTenders()
        {
            return tenderRepository.GetAllEntities().Where(inactiveTender => inactiveTender.Active.Equals(false));
        }

        public Tender AddEntity(Tender entity)
        {
            return tenderRepository.AddEntity(entity);
        }

        public void DeleteEntity(Tender entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tender> GetAllEntities()
        {
            return tenderRepository.GetAllEntities();
        }

        public Tender GetEntity(int id)
        {
            return tenderRepository.GetEntity(id);
        }

        public IEnumerable<Tender> GetTenderForCertainPeriod(DateTime startDate, DateTime endDate)
        {
            return tenderRepository.GetAllEntities().ToList().FindAll(t => DateTime.Compare(t.StartDate, startDate) >= 0 &&
                DateTime.Compare(t.EndDate, endDate) <= 0);
        }

        public Tender GetMedicamentForTender(String medicamentName)
        {
            return tenderRepository.GetAllEntities().ToList().Find(tender => tender.MedicamentName == medicamentName);
        }

        public void UpdateEntity(Tender entity)
        {
            tenderRepository.UpdateEntity(entity);
        }

        public Tender CloseTender(int tenderId)
        {
            Tender finishedTender = GetEntity(tenderId);
            if (finishedTender.Active == true)
            {
                finishedTender.Active = false;
            }
            UpdateEntity(finishedTender);
            return finishedTender;
        }
    }
}