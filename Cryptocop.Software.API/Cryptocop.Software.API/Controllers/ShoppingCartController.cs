using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{

    [Route("api/cart")]
    [ApiController]
    [Authorize]
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
            return Ok(_shoppingCartService.GetCartItems(User.Identity.Name));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCartItem([FromBody] ShoppingCartItemInputModel inputModel)
        {
            await _shoppingCartService.AddCartItem(User.Identity.Name, inputModel);
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult RemoveCartItem(int Id)
        {
            _shoppingCartService.RemoveCartItem(User.Identity.Name, Id);
            return NoContent();
        }

        [HttpPatch]
        [Route("{Id}")]
        public IActionResult UpdateCartItemQuantity([FromBody] ShoppingCartItemInputModel inputModel, int Id)
        {
            _shoppingCartService.UpdateCartItemQuantity(User.Identity.Name, Id, inputModel.Quantity);
            return NoContent();
        }

        [HttpDelete]
        [Route("")]
        public IActionResult ClearCart()
        {
            _shoppingCartService.ClearCart(User.Identity.Name);
            return NoContent();
        }
    }
}