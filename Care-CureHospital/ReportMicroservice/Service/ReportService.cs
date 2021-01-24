using ReportMicroservice.Domain;
using ReportMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportMicroservice.Service
{
    public class ReportService : IReportService
    {
        public ISftpService sftpService;
        public IReportRepository reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public ReportService(IReportRepository reportRepository, ISftpService sftpService)
        {
            this.sftpService = sftpService;
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

        public void SendReportSftp(Report report)
        {
            String reportFile = "Files\\Report_" + DateTime.Now.ToString("dd-MM-yyyy") + ".json";
            System.IO.File.WriteAllText(reportFile, enterReport(report));
            try
            {
                sftpService.UploadFile(reportFile);
            }
            catch (Exception e)
            {
                throw new Exception("The file can not be uploaded, because there where errors on the server side. Please try again later!", e);
            }
        }

        public String enterReport(Report report)
        {
            return "Report about medicament consumption: \n\n" + "Medicament name: " + report.MedicamentName + "\nQuantity: " + report.Quantity + "\nFrom date: " + report.FromDate + "\nTo date: " + report.ToDate;
        }
    }
}