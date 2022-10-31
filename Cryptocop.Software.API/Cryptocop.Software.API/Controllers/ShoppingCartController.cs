using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{

    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetCartItems()
        {
            return Ok(_shoppingCartService.GetCartItems());
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddCartItem([FromBody] ShoppingCartItemInputModel inputModel)
        {
            var id = _shoppingCartService.AddCartItem(inputModel);
            //call the external api using thye product identifier as an url parameter
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("/{Id}")]
        public IActionResult RemoveCartItem([FromBody] ShoppingCartItemInputModel inputModel)
        {
            _shoppingCartService.RemoveCartItem(inputModel);
            return NoContent();
        }

        [HttpPatch]
        [Route("/{Id}")]
        public IActionResult UpdateCartItemQuantity([FromBody] ShoppingCartItemInputModel inputModel)
        {
            _shoppingCartService.UpdateCartItemQuantity(inputModel);
            return NoContent();
        }

        [HttpDelete]
        [Route("")]
        public IActionResult ClearCart()
        {
            _shoppingCartService.ClearCart();
            return NoContent();
        }

    }
}