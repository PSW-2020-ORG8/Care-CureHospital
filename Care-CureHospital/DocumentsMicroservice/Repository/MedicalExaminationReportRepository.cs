using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Repository.MySQL;
using DocumentsMicroservice.Repository.MySQL.Stream;

namespace DocumentsMicroservice.Repository
{
    public class MedicalExaminationReportRepository : MySQLRepository<MedicalExaminationReport, int>, IMedicalExaminationReportRepository
    {
        public MedicalExaminationReportRepository(IMySQLStream<MedicalExaminationReport> stream)
            : base(stream)
        {
        }
    }
}
