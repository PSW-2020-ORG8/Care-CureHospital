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
    public class OfferController:ControllerBase
    {
        public OfferController() { }

        [HttpGet()] //api/offer
        public IActionResult GetAllOffers()
        {
            List<OfferDto> result = new List<OfferDto>();
            App.Instance().OfferService.GetAllEntities().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

       [HttpGet("activeTender")] 
        public IActionResult GetAllOffersActiveTender()
        {
            List<OfferDto> result = new List<OfferDto>();
            App.Instance().OfferService.GetAllOffersForActiveTender().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpGet("inactiveTender")]
        public IActionResult GetAllOffersInactiveTender()
        {
            List<OfferDto> result = new List<OfferDto>();
            App.Instance().OfferService.GetAllOffersForInactiveTender().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOffer(OfferDto dto)
        {
            Offer offer = OfferMapper.OfferDtoToOffer(dto);
            App.Instance().OfferService.AddEntity(offer);
            return Ok();
        }

        [HttpGet("winner")]
        public IActionResult ChooseTender(Offer entity)
        {
            App.Instance().EmailService.TenderWinner(entity);
            return Ok();
		}
        /* [HttpGet("winner")]
         public IActionResult ChooseTender(OfferDto dto)
         {
             //App.Instance().EmailService.TenderWinner();
             Offer offer = OfferMapper.OfferDtoToOffer(dto);
             App.Instance().OfferService.ChooseOffer(offer);
             return Ok();
         }
        */
        [HttpPut("chooseO/{id}")]
        public IActionResult ChooseOffer(int id)
        {
            return Ok(App.Instance().OfferService.ChooseOffer(id));
        }

        [HttpGet("notWinner")]
        public IActionResult ClosedTender()
        {
            App.Instance().EmailService.NotTenderWinner();
            return Ok();
        }
    }
}
