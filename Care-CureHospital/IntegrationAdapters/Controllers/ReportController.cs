using System.Collections.Generic;
using System.Linq;
using Backend;
using Microsoft.AspNetCore.Mvc;
using IntegrationAdapters.Dto;
using IntegrationAdapters.Mapper;

namespace IntegrationAdapters.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReportController:ControllerBase
    {
        public ReportController() { }
        
        [HttpGet]   //GET /api/report
        public IActionResult GetAllReports()
        {
            List<ReportDto> result = new List<ReportDto>();
            App.Instance().ReportService.GetAllEntities().ToList().ForEach(report => result.Add(ReportMapper.ReportToReportDto(report)));
            return Ok(result);
        }
    }
}
