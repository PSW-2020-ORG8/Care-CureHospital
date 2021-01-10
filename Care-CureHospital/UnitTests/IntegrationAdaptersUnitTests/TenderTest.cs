using Backend.Model.Tender;
using Backend.Repository.TenderRepository;
using Backend.Service.TenderService;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.IntegrationAdaptersUnitTests
{
    public class TenderTest
    {
       /* [Fact]
        public void Get_tenders()
        {
            TenderService tenderService = new TenderService(CreateStubRepository());

            List<Tender> results = (List<Tender>)tenderService.GetAllEntities();

            Assert.NotNull(results);
        }

        [Fact]
        public void Add_tender()
        {
            TenderService tenderService = new TenderService(CreateStubRepository());

            Tender tender = tenderService.AddEntity(new Tender(3, "Paracetamol", new DateTime(2021, 1, 5, 8, 30, 0), new DateTime(2021, 2, 5, 8, 30, 0), true));

            Assert.NotNull(tender);
        }

        [Fact]
        public void Find_active_tender()
        {
            TenderService tenderService = new TenderService(CreateStubRepository());

            List<Tender> tenders = (List<Tender>)tenderService.GetTenderForCertainPeriod(new DateTime(2021, 1, 7, 8, 30, 0), new DateTime(2021, 2, 7, 8, 30, 0));

            Assert.NotEmpty(tenders);

        }

        [Fact]
        public void Not_found_active_tender()
        {
            TenderService tenderService = new TenderService(CreateStubRepository());

            List<Tender> tenders = (List<Tender>)tenderService.GetTenderForCertainPeriod(new DateTime(2020, 10, 7, 8, 30, 0), new DateTime(2020, 12, 7, 8, 30, 0));

            Assert.Empty(tenders);

        }

        [Fact]
        public void Find_tender_for_medicament()
        {
            TenderService tenderService = new TenderService(CreateStubRepository());

            Tender tender = tenderService.GetMedicamentForTender("Vitamin B");

            Assert.NotNull(tender);
        }

        [Fact]
        public void Not_found_tender_for_medicament()
        {
            TenderService tenderService = new TenderService(CreateStubRepository());

            Tender tender = tenderService.GetMedicamentForTender("Defrinol");

            Assert.Null(tender);
        }

        private static ITenderRepository CreateStubRepository()
        {
            var stubRepository = new Mock<ITenderRepository>();
            var tenders = new List<Tender>();

            tenders.Add(new Tender(1, "Vitamin B", new DateTime(2020, 1, 5, 8, 30, 0), new DateTime(2020, 2, 5, 8, 30, 0), false));
            tenders.Add(new Tender(2, "Brufen", new DateTime(2021, 1, 7, 8, 30, 0), new DateTime(2021, 2, 7, 8, 30, 0), true));

            stubRepository.Setup(tenderRepository => tenderRepository.GetAllEntities()).Returns(tenders);
            stubRepository.Setup(tender => tender.AddEntity(It.IsAny<Tender>())).Returns(new Tender(1, "Vitamin B", new DateTime(2020, 1, 5, 8, 30, 0), new DateTime(2020, 2, 5, 8, 30, 0), false));

            return stubRepository.Object;
        }*/
    }
}
