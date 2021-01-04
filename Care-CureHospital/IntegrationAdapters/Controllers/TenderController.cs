using Backend;
using IntegrationAdapters.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            App.Instance().TenderService.SendNotification();
            return Ok();
        }

      /*  [HttpGet("all")] //tender
        public IActionResult GetAllTenders()
        {
            List<TenderDto> result = new List<TenderDto>();
            App.Instance().TenderService.GetAllEntities().ToList().ForEach(tender => result.Add(TenderMapper.TenderToTenderDto(tender)));
            return Ok(result);
        }*/
    }
}
