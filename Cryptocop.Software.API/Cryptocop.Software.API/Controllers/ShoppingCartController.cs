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
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddCartItem([FromBody] ShoppingCartItemInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("/{Id}")]
        public IActionResult RemoveCartItem([FromBody] ShoppingCartItemInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("/{Id}")]
        public IActionResult UpdateCartItemQuantity([FromBody] ShoppingCartItemInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("")]
        public IActionResult ClearCart()
        {
            throw new NotImplementedException();
        }

    }
}