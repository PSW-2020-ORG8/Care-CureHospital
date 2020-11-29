using Backend.Model.PatientDoctor;
using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Service.ExaminationSurgeryServices;
using Model.AllActors;
using Model.Doctor;
using Model.Manager;
using Model.Term;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WebAppPatientTests
{
    public class MedicalExaminationReportTests
    {
        [Fact]
        public void Find_Reports_With_Doctor_Searh_Parameter()
        {
            MedicalExaminationReportService service = new MedicalExaminationReportService(CreateStubRepository());

            List<MedicalExaminationReport> searchResult = service.FindReportsForDoctorParameter(1, "Milan");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Reports_With_Doctor_Searh_Parameter()
        {
            MedicalExaminationReportService service = new MedicalExaminationReportService(CreateStubRepository());

            List<MedicalExaminationReport> searchResult = service.FindReportsForDoctorParameter(1, "Milorad");

            Assert.Empty(searchResult);
        }

        [Fact]
        public void Find_Reports_With_Comment_Searh_Parameter()
        {
            MedicalExaminationReportService service = new MedicalExaminationReportService(CreateStubRepository());

            List<MedicalExaminationReport> searchResult = service.FindReportsForCommentParameter(1, "Sve");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Reports_With_Comment_Searh_Parameter()
        {
            MedicalExaminationReportService service = new MedicalExaminationReportService(CreateStubRepository());

            List<MedicalExaminationReport> searchResult = service.FindReportsForCommentParameter(1, "Bolnica");

            Assert.Empty(searchResult);
        }

        [Fact]
        public void Find_Reports_With_Date_Searh_Parameter()
        {
            MedicalExaminationReportService service = new MedicalExaminationReportService(CreateStubRepository());

            List<MedicalExaminationReport> searchResult = service.FindReportsForDateParameter(1, "2020-12-23");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Reports_With_Date_Searh_Parameter()
        {
            MedicalExaminationReportService service = new MedicalExaminationReportService(CreateStubRepository());

            List<MedicalExaminationReport> searchResult = service.FindReportsForDateParameter(1, "2021-12-23");

            Assert.Empty(searchResult);
        }

        [Fact]
        public void Find_Reports_With_Room_Searh_Parameter()
        {
            MedicalExaminationReportService service = new MedicalExaminationReportService(CreateStubRepository());

            List<MedicalExaminationReport> searchResult = service.FindReportsForRoomParameter(1, "101");

            Assert.NotEmpty(searchResult);
        }

        [Fact]
        public void Not_Found_Reports_With_Room_Searh_Parameter()
        {
            MedicalExaminationReportService service = new MedicalExaminationReportService(CreateStubRepository());

            List<MedicalExaminationReport> searchResult = service.FindReportsForRoomParameter(1, "501");

            Assert.Empty(searchResult);
        }

        private static IMedicalExaminationReportRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicalExaminationReportRepository>();

            var medicalExaminationReports = new List<MedicalExaminationReport>();

            medicalExaminationReports.Add(new MedicalExaminationReport(1, "Sve je bilo uredu na pregledu", new DateTime(2020, 10, 12), 1, new MedicalExamination(1, false, "Opis", 1, 2, 1, new Room(1, "101", new TypeOfRoom(), new DateTime(), new DateTime(), new List<InventaryRoom>()), new Doctor("pera", "123", "Milan", "Petrovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1))));
            medicalExaminationReports.Add(new MedicalExaminationReport(2, "Pacijent je dobro", new DateTime(2020, 11, 23), 1, new MedicalExamination(2, false, "Opis", 1, 2, 1, new Room(1, "102", new TypeOfRoom(), new DateTime(), new DateTime(), new List<InventaryRoom>()), new Doctor("pera", "123", "Jovan", "Simic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1))));
            medicalExaminationReports.Add(new MedicalExaminationReport(3, "Sve je bilo uredu na pregledu", new DateTime(2020, 10, 13), 1, new MedicalExamination(3, false, "Opis", 1, 2, 1, new Room(1, "201", new TypeOfRoom(), new DateTime(), new DateTime(), new List<InventaryRoom>()), new Doctor("pera", "123", "Dusan", "Petrovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1))));
            medicalExaminationReports.Add(new MedicalExaminationReport(4, "Pacijent je lose", new DateTime(2020, 12, 03), 1, new MedicalExamination(4, false, "Opis", 1, 2, 1, new Room(1, "202", new TypeOfRoom(), new DateTime(), new DateTime(), new List<InventaryRoom>()), new Doctor("pera", "123", "Milica", "Jovanovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1))));
            medicalExaminationReports.Add(new MedicalExaminationReport(5, "Sve je bilo uredu na pregledu", new DateTime(2020, 12, 23), 1, new MedicalExamination(5, false, "Opis", 1, 2, 1, new Room(1, "301", new TypeOfRoom(), new DateTime(), new DateTime(), new List<InventaryRoom>()), new Doctor("pera", "123", "Petar", "Stefanovic", "123", new DateTime(), "123", "email", new City(), new Specialitation()), new Patient(1))));

            stubRepository.Setup(medicaExaminationReportsRepository => medicaExaminationReportsRepository.GetAllEntities()).Returns(medicalExaminationReports);

            return stubRepository.Object;
        }
    }
}
