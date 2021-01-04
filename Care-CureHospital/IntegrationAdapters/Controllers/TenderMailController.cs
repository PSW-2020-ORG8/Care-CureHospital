using Backend;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Controllers
{
    public class TenderMailController
    {
        [HttpGet] //tender
        public IActionResult PublishTender()
        {
            App.Instance().TenderMailService.SendNotification();
            return Ok();
        }
    }
}
