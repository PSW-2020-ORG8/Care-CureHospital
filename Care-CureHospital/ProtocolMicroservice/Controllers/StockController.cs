using Microsoft.AspNetCore.Mvc;
using ProtocolMicroservice.Service;

namespace ProtocolMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMedicament()
        {
            return Ok(HttpService.SendGetRequestWithRestSharp());
        }
    }
}