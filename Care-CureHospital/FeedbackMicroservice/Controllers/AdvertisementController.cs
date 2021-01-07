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

        public AdvertisementController(IAdvertisementService advertisementService) 
        {
            this.advertisementService = advertisementService;
        }

        [HttpGet]       // GET /api/advertisement
        public IActionResult GetAllAdvertisements()
        {
            List<Advertisement> result = new List<Advertisement>();
            advertisementService.GetAllEntities().ToList().ForEach(advertisement => result.Add(advertisement));
            return Ok(result);
        }
    }
}
