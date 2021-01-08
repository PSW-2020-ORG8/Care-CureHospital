using EPrescriptionMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescriptionMicroservice.Service
{
    public interface IEPrescriptionService : IService<EPrescription, int>
    {
        public void SendPrescriptionSftp();
    }
}
