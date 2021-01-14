namespace TenderMicroservice.Service
{
    public interface IEmailService
    {
        public void SendNotification();
        public void TenderWinner();
        public void NotTenderWinner();
    }
}
