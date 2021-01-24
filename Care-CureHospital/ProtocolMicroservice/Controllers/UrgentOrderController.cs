using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProtocolMicroservice.Domain;
using ProtocolMicroservice.Dto;
using ProtocolMicroservice.Mapper;
using ProtocolMicroservice.Service;
using System.Collections.Generic;
using System.Linq;

namespace ProtocolMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentOrderController : ControllerBase
    {
        private IUrgentOrderService urgentOrderService;
        private IWebHostEnvironment env;

        public UrgentOrderController(IWebHostEnvironment env, IUrgentOrderService urgentOrderService)
        {
            this.env = env;
            this.urgentOrderService = urgentOrderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            List<UrgentMedicineOrderDto> result = new List<UrgentMedicineOrderDto>();
            this.urgentOrderService.GetAllEntities().ToList().ForEach(order => result.Add(UrgentMedicineOrderMapper.UrgentMedicineOrderToUrgentMedicineOrderDto(order)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult GetMedicament(UrgentMedicineOrder medicineOrder)
        {
            this.urgentOrderService.SendRequestForOrder(medicineOrder);
            return Ok();
        }

        [HttpPost("sftp")]
        public IActionResult GetMedicamentSftp(UrgentMedicineOrder medicineOrder)
        {
            this.urgentOrderService.SendRequestForOrderSftp(medicineOrder);
            return Ok();
        }
    }
}