using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetStoredPaymentCards()
        {
            return Ok(_paymentService.GetStoredPaymentCards(User.Identity.Name));
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddPaymentCard([FromBody] PaymentCardInputModel inputModel)
        {
            _paymentService.AddPaymentCard(User.Identity.Name, inputModel);
            return StatusCode(201);
        }


    }
}