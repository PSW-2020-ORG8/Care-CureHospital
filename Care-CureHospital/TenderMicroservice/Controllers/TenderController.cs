using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TenderMicroservice.Dto;
using TenderMicroservice.Mapper;
using TenderMicroservice.Service;

namespace TenderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private ITenderService tenderService;
        private IEmailService emailService;
  
        public TenderController(ITenderService tenderService, IEmailService emailService)
        {
            this.tenderService = tenderService;
            this.emailService = emailService;
        }

        [HttpGet] //tender
        public IActionResult PublishTender()
        {
           this.emailService.SendNotification();
           return Ok();
        }

        [HttpGet("getActiveTender")]
        public IActionResult GetActiveTender()
        {
            List<TenderDto> result = new List<TenderDto>();
            this.tenderService.GetActiveTenders().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

        [HttpGet("getInactiveTender")]
        public IActionResult GetInactiveTender()
        {
            List<TenderDto> result = new List<TenderDto>();
            this.tenderService.GetInactiveTenders().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

        [HttpGet("allTender")] //allTender
        public IActionResult GetAllTenders()
        {
            List<TenderDto> result = new List<TenderDto>();
            this.tenderService.GetAllEntities().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }

        [HttpPut("closeTender/{tenderId}")]
        public IActionResult CloseTender(int tenderId)
        {
            return Ok(this.tenderService.CloseTender(tenderId));
        }
    }
}
