using Backend.Model.BlogAndNotification;
using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using IntegrationAdapters.Dto;
using Microsoft.AspNetCore.Mvc;
using IntegrationAdapters.Mapper;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        public TenderController() { }

        [HttpGet] //tender
        public IActionResult PublishTender()
        {
            App.Instance().EmailService.SendNotification();
            return Ok();
        }

        [HttpGet("getActiveTender")]
        public IActionResult GetActiveTender()
        {
            List<TenderDto> result = new List<TenderDto>();
            App.Instance().TenderService.GetActiveTenders().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

       [HttpGet("allTender")] //allTender
        public IActionResult GetAllTenders()
        {
            List<TenderDto> result = new List<TenderDto>();
            App.Instance().TenderService.GetAllEntities().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }
    }
}
