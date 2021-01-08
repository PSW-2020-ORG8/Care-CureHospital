using Backend.Model.Tender;
using Backend.Repository.TenderRepository;
using System;
using System.Net.Mail;

namespace Backend.Service.EmailService
{
    public class EmailService
    {
        public ITenderRepository tenderRepository;
        string hospital = "hospitalssystem@gmail.com";
        string hospitalPassword = "bolnica123";
        string pharmacy = "pharmacysistem@gmail.com";
        string benu = "benupharmacy@gmail.com";
        Offer offer = new Offer();
        Tender tender = new Tender();

        public void SendNotification()
        {
            try
            {
                Console.WriteLine("E-mail with information about publishing tender is sending!");
                MailMessage email = new MailMessage();
                SmtpClient smpt = new SmtpClient("smtp.gmail.com");

                email.From = new MailAddress(hospital);
                email.To.Add(pharmacy);
                email.To.Add(benu);
                email.Subject = ("We published tender!");
                email.Body = "New tender is published. You can see information and fill the form for participate here - http://localhost:4200/tender";

                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential(hospital, hospitalPassword);
                smpt.EnableSsl = true;
                smpt.Send(email);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("ERROR!");
            }
        }

        public void TenderWinner()
        {
            try
            {
                Console.WriteLine("E-mail with information about tender winner is sending!");
                MailMessage email = new MailMessage();
                SmtpClient smpt = new SmtpClient("smtp.gmail.com");

                email.From = new MailAddress(hospital);
                if (offer.PharmacyName == "Jankovic")
                {
                    email.To.Add(pharmacy);
                }
                else
                {
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
                Console.WriteLine("ERROR!");
            }
        }

        public void NotTenderWinner()
        {
            try
            {
                Console.WriteLine("E-mail with information about closing tender is sending!");
                MailMessage email = new MailMessage();
                SmtpClient smpt = new SmtpClient("smtp.gmail.com");

                email.From = new MailAddress(hospital);
                email.To.Add("pharmacysistem@gmail.com");
                email.Subject = ("Tender is closed!");
                email.Body = "We are glad you took part in our tender!";

                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential(hospital, hospitalPassword);
                smpt.EnableSsl = true;
                smpt.Send(email);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("ERROR!");
            }
        }
    }
}
