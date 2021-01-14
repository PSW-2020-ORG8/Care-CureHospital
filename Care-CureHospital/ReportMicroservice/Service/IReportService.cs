using ReportMicroservice.Domain;

namespace ReportMicroservice.Service
{
    public interface IReportService : IService<Report, int>
    {
       public void SendReportSftp();
    }
}
