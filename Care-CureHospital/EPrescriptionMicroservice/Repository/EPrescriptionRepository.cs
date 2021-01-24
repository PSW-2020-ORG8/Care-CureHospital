using EPrescriptionMicroservice.Domain;
using EPrescriptionMicroservice.Repository.MySQL;
using EPrescriptionMicroservice.Repository.MySQL.Stream;

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