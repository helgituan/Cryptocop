using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Route("/api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        /*
        [HttpGet]
        [Route("api/addresses")]
        public IActionResult GetAllAddresses()
        {
            return Ok(_addressService.GetAllAddresses);
        }
        */
        [HttpPost]
        [Route("")]
        public IActionResult AddAddress([FromBody] AddressInputModel inputModel)
        {
            _addressService.AddAddress("", inputModel);
            return Ok();
        }
    }
}