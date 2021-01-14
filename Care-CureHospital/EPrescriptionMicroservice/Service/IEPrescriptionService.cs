using EPrescriptionMicroservice.Domain;
using System.Collections.Generic;

namespace EPrescriptionMicroservice.Service
{
    public interface IEPrescriptionService : IService<EPrescription, int>
    {
        public void SendPrescriptionSftp();
        public List<EPrescription> GetEPrescriptionsForPatient(int patientID);

        public List<EPrescription> FindEPrescriptionsForDateParameter(int patientID, string publishingDate);

        public List<EPrescription> FindEPrescriptionsForCommentParameter(int patientID, string comment);

        public EPrescription GetEPrescriptionForPatient(int patientID);
    }
}
