using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.BlogAndNotification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Model.DoctorMenager;
using Service.MedicamentService;
using Backend.Model.DoctorMenager;
using IntegrationAdapters.Dto;
using Backend.Service.DirectorService;
using IntegrationAdapters.Mapper;
using System.Web.Http.Cors;


namespace IntegrationAdapters.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public ReportController() { }
        
        [HttpGet]   //GET /api/report

        public IActionResult GetAllReports()
        {
            List<ReportDto> result = new List<ReportDto>();

            App.Instance().ReportService.GetAllEntities().ToList().ForEach(report => result.Add(ReportMapper.ReportToReportDto(report)));
            return Ok(result);
           
        }

        [HttpPost]   //POST /api/report
        public IActionResult AddReport(ReportDto dto)
        {
            Report report = ReportMapper.ReportDtoToReport(dto, null);
            App.Instance().ReportService.AddEntity(report);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReport(int id)
        {
            Report report = App.Instance().ReportService.FindReportById(id);
            if(report == null)
            {
                return BadRequest();
            }
           
            App.Instance().ReportService.DeleteEntity(report);
            
            
            return Ok(report);
        }
    }
}
