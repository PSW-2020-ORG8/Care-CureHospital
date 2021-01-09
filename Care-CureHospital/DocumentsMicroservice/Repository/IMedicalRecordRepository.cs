using DocumentsMicroservice.Domain;

namespace DocumentsMicroservice.Repository
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, int>
    {
        MedicalRecord GetMedicalRecordByPatient(Patient patient);
    }
}
