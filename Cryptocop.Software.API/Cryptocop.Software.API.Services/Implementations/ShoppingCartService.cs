using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.Exceptions;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICryptoCurrencyService _cryptoCurrencyService;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, ICryptoCurrencyService cryptoCurrencyService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _cryptoCurrencyService = cryptoCurrencyService;
        }

        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email) => _shoppingCartRepository.GetCartItems(email);

        public async Task AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemInputModel)
        {
            var coin = shoppingCartItemInputModel.ProductIdentifier;
            var cryptoCurrencies = await _cryptoCurrencyService.GetAvailableCryptocurrencies();

            bool coinFound = false;
            foreach (var crypto in cryptoCurrencies)
            {

                if (crypto.symbol.ToLower() == coin.ToLower())
                {
                    coinFound = true;
                    _shoppingCartRepository.AddCartItem(email, shoppingCartItemInputModel, crypto.price_usd);
                    return;
                }
            }

            if (coinFound == false)
            {
                throw new ResourceNotFoundException("The name of the product identifier is not supported");
            }

        }

        public void RemoveCartItem(string email, int id) => _shoppingCartRepository.RemoveCartItem(email, id);

        public void UpdateCartItemQuantity(string email, int id, float quantity) => _shoppingCartRepository.UpdateCartItemQuantity(email, id, quantity);

        public void ClearCart(string email) => _shoppingCartRepository.ClearCart(email);
    }
}
