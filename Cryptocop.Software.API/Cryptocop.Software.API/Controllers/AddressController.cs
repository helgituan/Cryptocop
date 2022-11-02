using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Cryptocop.Software.API.Controllers
{
    [Route("/api/addresses")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAddresses()
        {
            //öruglega email => thingy
            return Ok(_addressService.GetAllAddresses(User.Identity.Name));
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddAddress([FromBody] AddressInputModel inputModel)
        {
            _addressService.AddAddress(User.Identity.Name, inputModel);
            return StatusCode(201);
        }
        [HttpDelete]
        [Route("{addressId}")]
        public IActionResult DeleteAddress(int addressId)
        {
            _addressService.DeleteAddress(User.Identity.Name, addressId);
            return NoContent();
        }
    }
}