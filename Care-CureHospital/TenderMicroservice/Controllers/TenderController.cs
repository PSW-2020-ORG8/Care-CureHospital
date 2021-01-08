using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        public TenderController() { }

        [HttpGet] //tender
        public IActionResult PublishTender()
        {
           this.EmailService.SendNotification();
            return Ok();
        }

        [HttpGet("getActiveTender")]
        public IActionResult GetActiveTender()
        {
            List<TenderDto> result = new List<TenderDto>();
            this.TenderService.GetActiveTenders().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

        [HttpGet("getInactiveTender")]
        public IActionResult GetInactiveTender()
        {
            List<TenderDto> result = new List<TenderDto>();
            this.TenderService.GetInactiveTenders().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

        [HttpGet("allTender")] //allTender
        public IActionResult GetAllTenders()
        {
            List<TenderDto> result = new List<TenderDto>();
            this.TenderService.GetAllEntities().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

        [HttpPut("closeTender/{tenderId}")]
        public IActionResult CloseTender(int tenderId)
        {
            return Ok(this.TenderService.CloseTender(tenderId));
        }
    }
}
