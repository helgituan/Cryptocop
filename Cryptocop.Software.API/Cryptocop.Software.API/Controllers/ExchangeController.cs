using Cryptocop.Software.API.Models.Exceptions;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/exchanges")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {

        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetExchanges([FromQuery] int pageNumber = 1)
        {
            try
            {
                var res = await _exchangeService.GetExchanges(pageNumber);
                return Ok(res);

            }
            catch (System.NullReferenceException)
            {
                throw new ResourceNotFoundException("Page number too large");

            }
        }

    }
}