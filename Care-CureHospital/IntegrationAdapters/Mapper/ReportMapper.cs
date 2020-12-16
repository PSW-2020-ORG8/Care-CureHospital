using IntegrationAdapters.Dto;
using Backend.Model.DoctorMenager;

namespace IntegrationAdapters.Mapper
{
    public class ReportMapper
    {
        public static ReportDto ReportToReportDto(Report report)
        {
            ReportDto dto = new ReportDto();
            dto.Id = report.Id;
            dto.MedicamentName = report.MedicamentName;
            dto.Quantity = report.Quantity;
            dto.FromDate = report.FromDate.ToString("dd.MM.yyyy. HH:mm");
            dto.ToDate = report.ToDate.ToString("dd.MM.yyyy. HH:mm");
            return dto;
        }
    }
}
