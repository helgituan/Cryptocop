using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        // TODO: Setup routes
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetStoredPaymentCards()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddPaymentCard()
        {
            throw new NotImplementedException();
        }


    }
}