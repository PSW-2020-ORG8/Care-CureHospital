﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.DoctorMenager;
using Model.DoctorMenager;
using Backend.Repository.DirectorRepository;
using Service;

namespace Backend.Service.DirectorService
{
    public class ReportService : IService<Report, int>
    {
        public IReportRepository reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public Report GetEntity(int id)
        {
            return reportRepository.GetEntity(id);
        }

        public IEnumerable<Report> GetReportForCertainPeriod(DateTime fromDate, DateTime toDate)
        {
             return reportRepository.GetAllEntities().ToList().FindAll(r => DateTime.Compare(r.FromDate, fromDate) >= 0 &&
                 DateTime.Compare(r.ToDate, toDate) <= 0);

        }

        public IEnumerable<Report> GetAllEntities()
        {
            return reportRepository.GetAllEntities();
        }

        public Report AddEntity(Report entity)
        {
            return reportRepository.AddEntity(entity);
        }

        public void UpdateEntity(Report entity)
        {
            reportRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Report entity)
        {
            reportRepository.DeleteEntity(entity);
        }
    }



}
