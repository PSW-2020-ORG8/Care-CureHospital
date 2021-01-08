using Microsoft.AspNetCore.Mvc;
using ReportMicroservice.Domain;
using ReportMicroservice.Dto;
using ReportMicroservice.Mapper;
using ReportMicroservice.Service;
using System.Collections.Generic;
using System.Linq;

namespace ReportMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        public ReportController() { }

        [HttpGet]   //GET /api/report
        public IActionResult GetAllReports()
        {
            List<ReportDto> result = new List<ReportDto>();
            this.reportService.GetAllEntities().ToList().ForEach(report => result.Add(ReportMapper.ReportToReportDto(report)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddReport(ReportDto dto)
        {
            Report report = ReportMapper.ReportDtoToReport(dto);
            this.reportService.AddEntity(report);
            return Ok();
        }

        [HttpPost("send")]
        public IActionResult SendReport()
        {
            this.reportService.SendReportSftp();
            return Ok();
        }
    }
}
