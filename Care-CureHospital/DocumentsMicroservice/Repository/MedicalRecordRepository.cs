using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Repository.MySQL;
using DocumentsMicroservice.Repository.MySQL.Stream;

namespace DocumentsMicroservice.Repository
{
    public class MedicalRecordRepository : MySQLRepository<MedicalRecord, int>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(IMySQLStream<MedicalRecord> stream)
           : base(stream)
        {
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
        {
            foreach (MedicalRecord medicalRecord in GetAllEntities())
            {
                if (medicalRecord.Patient.GetId() == patient.GetId())
                    return medicalRecord;
            }            
            return null;
        }
    }
}
