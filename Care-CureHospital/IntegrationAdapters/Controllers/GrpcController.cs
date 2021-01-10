using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMedicamentWithGrpc(string med)
        {
            return Ok();
        }
    }
}
