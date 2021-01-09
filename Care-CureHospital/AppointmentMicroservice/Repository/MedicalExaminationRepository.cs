using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Repository.MySQL;
using AppointmentMicroservice.Repository.MySQL.Stream;

namespace AppointmentMicroservice.Repository
{
    public class MedicalExaminationRepository : MySQLRepository<MedicalExamination, int>, IMedicalExaminationRepository
    {
        public MedicalExaminationRepository(IMySQLStream<MedicalExamination> stream)
            : base(stream)
        {
        }
    }
}