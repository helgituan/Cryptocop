using System.Collections.Generic;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Entities;
using Cryptocop.Software.API.Repositories.Contexts;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System;
namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        public ShoppingCartRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email)
        {
            return _dbContext.ShoppingCartItem.Select(s => _mapper.Map<ShoppingCartItemDto>).AsEnumerable();
        }

        public void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem, float priceInUsd)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCartItem(string email, int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            throw new System.NotImplementedException();
        }

        public void ClearCart(string email)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCart(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}