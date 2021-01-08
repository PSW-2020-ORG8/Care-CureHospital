using EPrescriptionMicroservice.Domain;
using EPrescriptionMicroservice.Repository.MySQL;
using EPrescriptionMicroservice.Repository.MySQL.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescriptionMicroservice.Repository
{
    
    public class EPrescriptionRepository : MySQLRepository<EPrescription, int>, IEPrescriptionRepository
    { 
        public EPrescriptionRepository(IMySQLStream<EPrescription> stream)
            : base(stream)
        {
        }
    }
    
}
