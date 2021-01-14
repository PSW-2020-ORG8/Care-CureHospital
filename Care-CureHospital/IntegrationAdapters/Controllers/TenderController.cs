using System.Collections.Generic;
using System.Linq;
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

        [HttpGet] 
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

        [HttpGet("getInactiveTender")]
        public IActionResult GetInactiveTender()
        {
            List<TenderDto> result = new List<TenderDto>();
            App.Instance().TenderService.GetInactiveTenders().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

        [HttpGet("allTender")] 
        public IActionResult GetAllTenders()
        {
            List<TenderDto> result = new List<TenderDto>();
            App.Instance().TenderService.GetAllEntities().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

        [HttpPut("closeTender/{tenderId}")]
        public IActionResult CloseTender(int tenderId)
        {
            return Ok(App.Instance().TenderService.CloseTender(tenderId));
        }
    }
}
