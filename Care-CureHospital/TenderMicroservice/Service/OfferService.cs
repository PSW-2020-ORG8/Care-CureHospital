using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using TenderMicroservice.Domain;
using TenderMicroservice.Repository;

namespace TenderMicroservice.Service
{
    public class OfferService : IOfferService
    {
        public ITenderRepository tenderRepository;
        string hospital = "hospitalssystem@gmail.com";
        string hospitalPassword = "bolnica123";
        string pharmacy = "pharmacysistem@gmail.com";
        string benu = "benupharmacy@gmail.com";

        public IOfferRepository offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public Offer AddEntity(Offer entity)
        {
            Tender tender = new Tender();
            entity.ActiveTender = true;
            if (tender.Id == 1)
            {
                entity.TenderId = 1;
            }
            else
            {
                entity.TenderId = 2;
            }
            return offerRepository.AddEntity(entity);
        }

        public Offer ChooseOffer(int id)
        {
            Offer choosen = GetEntity(id);
            if (choosen.Choosen == false)
            {
                choosen.Choosen = true;
            }
            TenderWinner(id);
            UpdateEntity(choosen);
            return choosen;
        }

        public void TenderWinner(int id)
        {
            try
            {
                Console.WriteLine("E-mail with information about tender winner is sending!");
                MailMessage email = new MailMessage();
                SmtpClient smpt = new SmtpClient("smtp.gmail.com");

                email.From = new MailAddress(hospital);
                Offer choosen = GetEntity(id);
                if (choosen.Id == 1)
                {
                    email.To.Add(pharmacy);
                }
                else { 

                    email.To.Add(benu);
                }
                email.Subject = ("You are tender winner! Congratulations!");
                email.Body = "We look forward to your work and successful cooperation.";

                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential(hospital, hospitalPassword);
                smpt.EnableSsl = true;
                smpt.Send(email);
            }
            catch (SmtpException ex)
            {
                throw new SmtpException("Dear user, something went wrong on server side so it's not possible to send an email now. Please try later.", ex);
            }
        }

        public IEnumerable<Offer> GetAllEntities()
        {
            return offerRepository.GetAllEntities();
        }

        public Offer GetEntity(int id)
        {
            return offerRepository.GetEntity(id);
        }

        public void UpdateEntity(Offer entity)
        {
            offerRepository.UpdateEntity(entity);
        }

        public List<Offer> GetAllOffersForActiveTender()
        {
            return GetAllEntities().ToList().Where(offer => offer.ActiveTender.Equals(true)).ToList();
        }

        public List<Offer> GetAllOffersForInactiveTender()
        {
            return GetAllEntities().ToList().Where(offer => offer.ActiveTender.Equals(false)).ToList();
        }

        public void DeleteEntity(Offer entity)
        {
            throw new NotImplementedException();
        }
    }
}
