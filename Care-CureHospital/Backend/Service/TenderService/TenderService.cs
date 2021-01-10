using Backend.Model.Tender;
using Backend.Repository.TenderRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
=======
using System.Net.Mail;
>>>>>>> b10116143c5695dc36a82c8a5e93d7760c23e26a

namespace Backend.Service.TenderService
{
    public class TenderService : IService<Tender, int>
    {
        string hospital = "hospitalssystem@gmail.com";
        string hospitalPassword = "bolnica123";
        string pharmacy = "pharmacysistem@gmail.com";
        string benu = "benupharmacy@gmail.com";
        Offer offer = new Offer();
        Tender tender = new Tender();

        public ITenderRepository tenderRepository;

        public IEnumerable<Tender> GetActiveTenders()
        {
            return tenderRepository.GetAllEntities().Where(activeTender => activeTender.Active.Equals(true));
        }

        public IEnumerable<Tender> GetInactiveTenders()
        {
            return tenderRepository.GetAllEntities().Where(inactiveTender => inactiveTender.Active.Equals(false));
        }

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
            if (finishedTender.Active == true && finishedTender.ChoosenOffer == true)
            {
                finishedTender.Active = false;
            }
            else
            {
                finishedTender.Active = true;
            }
            NotTenderWinner();
            UpdateEntity(finishedTender);
            return finishedTender;
        }

        public void NotTenderWinner()
        {
            try
            {
                Console.WriteLine("E-mail with information about closing tender is sending!");
                MailMessage email = new MailMessage();
                SmtpClient smpt = new SmtpClient("smtp.gmail.com");

                email.From = new MailAddress(hospital);

                if(offer.Id == 1) { 
                    email.To.Add(pharmacy);
                }
                else
                {
                    email.To.Add(benu);
                }
           
                email.Subject = ("Tender is closed!");
                email.Body = "We are glad you took part in our tender!";

                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential(hospital, hospitalPassword);
                smpt.EnableSsl = true;
                smpt.Send(email);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
