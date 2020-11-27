using Backend.Model.DoctorMenager;
using Backend.Repository.DirectorRepository;
using Backend.Service.DirectorService;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IntegrationAdaptersTests
{
    public class ReportTest
    {
        [Fact]
        public void Get_reports()
        {
            ReportService reportService = new ReportService(CreateStubRepository());

            List<Report> results = (List<Report>)reportService.GetAllEntities();

            Assert.NotNull(results);
        }

        [Fact]
        public void Add_report()
        {
            ReportService reportService = new ReportService(CreateStubRepository());

            Report report = reportService.AddEntity(new Report(10, 1, "Paracetamol", 10, new DateTime(2020, 1, 6, 8, 30, 0), new DateTime(2020, 12, 6, 8, 30, 0)));

            Assert.NotNull(report);
        }

        [Fact]
        public void Get_medications()
        {
            ReportService reportService = new ReportService(CreateStubRepository());

            List<string> results = (List<string>)reportService.GetAllNames();

            Assert.NotNull(results);
        }

        /*public void Report_saved()
        {
            ReportService reportService = new ReportService(CreateStubRepository());
            ;
        }*/

        public void Find_medicament_for_the_certain_period()
        {

        }

        private static IReportRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IReportRepository>();

            var reports = new List<Report>();
            reports.Add(new Report(1, 3, "Brufen", 12, new DateTime(2019, 11, 6, 8, 30, 0), new DateTime(2019, 12, 6, 8, 30, 0)));
            reports.Add(new Report(2, 2, "Vitamin C", 102, new DateTime(2020, 5, 6, 8, 30, 0), new DateTime(2020, 11, 6, 8, 30, 0)));
            reports.Add(new Report(3, 1, "Paracetamol", 10, new DateTime(2020, 1, 6, 8, 30, 0), new DateTime(2020, 12, 6, 8, 30, 0)));


            stubRepository.Setup(reportRepository => reportRepository.GetAllEntities()).Returns(reports);
            stubRepository.Setup(report => report.AddEntity(It.IsAny<Report>())).Returns(new Report(1, 3, "Brufen", 12, new DateTime(2019, 11, 6, 8, 30, 0), new DateTime(2019, 12, 6, 8, 30, 0)));

            return stubRepository.Object;
        }
    }
}
