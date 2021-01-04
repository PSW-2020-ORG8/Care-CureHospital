using System.Collections.Generic;
using System.Linq;
using Backend;
using Backend.Model.Pharmacy;
using Microsoft.AspNetCore.Mvc;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        public AdvertisementController() { }

        [HttpGet]       // GET /api/advertisement
        public IActionResult GetAllAdvertisements()
        {
            List<Advertisement> result = new List<Advertisement>();
            App.Instance().AdvertisementService.GetAllEntities().ToList().ForEach(advertisement => result.Add(advertisement));
            return Ok(result);
        }
    }
}
