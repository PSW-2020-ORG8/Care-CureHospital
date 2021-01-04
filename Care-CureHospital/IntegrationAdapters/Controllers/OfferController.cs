using Backend;
using Backend.Model.Tender;
using IntegrationAdapters.Dto;
using IntegrationAdapters.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        public OfferController() { }

        [HttpGet] //api/offer
        public IActionResult GetAllOffers()
        {
            List<OfferDto> result = new List<OfferDto>();
            App.Instance().OfferService.GetAllEntities().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOffer(OfferDto dto)
        {
            Offer offer = OfferMapper.OfferDtoToOffer(dto);
            App.Instance().OfferService.AddEntity(offer);
            return Ok();
        }
    }
}
