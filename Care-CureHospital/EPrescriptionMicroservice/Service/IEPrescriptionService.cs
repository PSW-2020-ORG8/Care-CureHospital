using EPrescriptionMicroservice.Domain;

namespace EPrescriptionMicroservice.Service
{
    public interface IEPrescriptionService : IService<EPrescription, int>
    {
        public void SendPrescriptionSftp();
    }
}
