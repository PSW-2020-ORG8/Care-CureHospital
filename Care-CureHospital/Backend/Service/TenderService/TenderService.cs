using Backend.Model.Tender;
using Backend.Repository.TenderRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.TenderService
{
    public class TenderService : IService<Tender, int>
    {
        public ITenderRepository tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            this.tenderRepository = tenderRepository;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
