using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
        private ISftpService sftpService;
        private IReportService reportService;
        private readonly IWebHostEnvironment env;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet]  
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
        public IActionResult SendReport(Report report)
        {
            if (env.IsDevelopment())
            {
                 this.reportService.SendReportSftp(report);
            }
            return Ok();
        }
    }
}