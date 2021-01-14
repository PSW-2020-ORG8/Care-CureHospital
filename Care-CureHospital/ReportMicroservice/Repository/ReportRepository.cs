using ReportMicroservice.Domain;
using ReportMicroservice.Repository.MySQL;
using ReportMicroservice.Repository.MySQL.Stream;

namespace ReportMicroservice.Repository
{
    public class ReportRepository : MySQLRepository<Report, int>, IReportRepository
    {
        public ReportRepository(IMySQLStream<Report> stream)
            : base(stream)
        {
        }
    }
}
