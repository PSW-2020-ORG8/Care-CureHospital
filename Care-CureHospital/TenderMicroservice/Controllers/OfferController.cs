using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderMicroservice.Dto;

namespace TenderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        public OfferController() { }

        [HttpGet()] //api/offer
        public IActionResult GetAllOffers()
        {
            List<OfferDto> result = new List<OfferDto>();
            this.OfferService.GetAllEntities().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpGet("activeTender")]
        public IActionResult GetAllOffersActiveTender()
        {
            List<OfferDto> result = new List<OfferDto>();
           this.OfferService.GetAllOffersForActiveTender().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpGet("inactiveTender")]
        public IActionResult GetAllOffersInactiveTender()
        {
            List<OfferDto> result = new List<OfferDto>();
            this.OfferService.GetAllOffersForInactiveTender().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOffer(OfferDto dto)
        {
            Offer offer = OfferMapper.OfferDtoToOffer(dto);
            this.OfferService.AddEntity(offer);
            return Ok();
        }

        [HttpGet("winner")]
        public IActionResult ChooseTender()
        {
            this.EmailService.TenderWinner();
            return Ok();
        }

        [HttpGet("notWinner")]
        public IActionResult ClosedTender()
        {
            this.EmailService.NotTenderWinner();
            return Ok();
        }

    }
}
