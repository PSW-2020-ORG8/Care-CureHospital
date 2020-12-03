using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.DoctorMenager;
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

        public static Report ReportDtoToReport(ReportDto dto, Report report)
        {
            Report newReport = new Report();

            newReport.Id = dto.Id;
            newReport.MedicamentId = dto.MedicamentId;
            newReport.MedicamentName = dto.MedicamentName;
            newReport.Quantity = dto.Quantity;
            newReport.FromDate = DateTime.Now;
            newReport.ToDate = DateTime.Now;
            return newReport;
        }
    }
}
