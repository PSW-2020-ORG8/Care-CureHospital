using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private IAdvertisementService advertisementService;
        private IDomainEventService domainEventService;

        public AdvertisementController(IAdvertisementService advertisementService, IDomainEventService domainEventService) 
        {
            this.advertisementService = advertisementService;
            this.domainEventService = domainEventService;
        }

        [HttpGet]       // GET /api/advertisement
        public IActionResult GetAllAdvertisements()
        {
            domainEventService.Save(new URLEvent("/api/advertisement", "GET"));
            List<Advertisement> result = new List<Advertisement>();
            advertisementService.GetAllEntities().ToList().ForEach(advertisement => result.Add(advertisement));
            return Ok(result);
        }
    }
}
