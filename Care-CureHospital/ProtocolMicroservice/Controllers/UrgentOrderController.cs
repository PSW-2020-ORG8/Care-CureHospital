using Microsoft.AspNetCore.Mvc;
using ProtocolMicroservice.Service;

namespace ProtocolMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentOrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMedicament()
        {
            return Ok(UrgentOrderService.SendRequestForOrder());
        }
    }
}