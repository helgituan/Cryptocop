using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
namespace Cryptocop.Software.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders(User.Identity.Name);
            return Ok(orders);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewOrder([FromBody] OrderInputModel inputModel)
        {
            _orderService.CreateNewOrder(User.Identity.Name, inputModel);
            return StatusCode(201);
        }
    }
}