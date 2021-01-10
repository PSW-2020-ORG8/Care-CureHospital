using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TenderMicroservice.Domain;
using TenderMicroservice.Dto;
using TenderMicroservice.Mapper;
using TenderMicroservice.Service;

namespace TenderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private IOfferService offerService;
        private IEmailService emailService;
        private ITenderService tenderService;

        public OfferController(IOfferService offerService, IEmailService emailService, ITenderService tenderService)
        {
            this.offerService = offerService;
            this.emailService = emailService;
            this.tenderService = tenderService;
        }

        [HttpGet()] 
        public IActionResult GetAllOffers()
        {
            List<OfferDto> result = new List<OfferDto>();
            this.offerService.GetAllEntities().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpGet("activeTender")]
        public IActionResult GetAllOffersActiveTender()
        {
            List<OfferDto> result = new List<OfferDto>();
           this.offerService.GetAllOffersForActiveTender().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpGet("inactiveTender")]
        public IActionResult GetAllOffersInactiveTender()
        {
            List<OfferDto> result = new List<OfferDto>();
            this.offerService.GetAllOffersForInactiveTender().ToList().ForEach(offer => result.Add(OfferMapper.OfferToOfferDto(offer)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOffer(OfferDto dto)
        {
            Offer offer = OfferMapper.OfferDtoToOffer(dto);
            this.offerService.AddEntity(offer);
            return Ok();
        }

        [HttpGet("winner")]
        public IActionResult ChooseTender()
        {
            this.emailService.TenderWinner();
            return Ok();
        }

        [HttpGet("notWinner")]
        public IActionResult ClosedTender()
        {
            this.emailService.NotTenderWinner();
            return Ok();
        }
    }
}
