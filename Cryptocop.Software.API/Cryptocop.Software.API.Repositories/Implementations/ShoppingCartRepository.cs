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
using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Models.Exceptions;

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
            var shoppingCart = _dbContext.ShoppingCart.Include(s => s.User).Include(s => s.Items).Where(s => s.User.Email == email);
            if (shoppingCart.FirstOrDefault() == null)
            {
                throw new ResourceNotFoundException("Shoppingcart not found");
            }
            return shoppingCart.AsEnumerable().Select(s => s.Items.Select(i =>
            {
                var res = _mapper.Map<ShoppingCartItemDto>(i);
                res.TotalPrice = i.Quantity * i.UnitPrice;
                return res;
            })).FirstOrDefault();
        }

        public void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemInputModel, float priceInUsd)
        {
            var shoppingCartItem = new ShoppingCartItem
            {
                ProductIdentifier = shoppingCartItemInputModel.ProductIdentifier,
                Quantity = shoppingCartItemInputModel.Quantity,
                UnitPrice = priceInUsd
            };

            var shoppingCart = _dbContext
                                .ShoppingCart
                                .Include(s => s.User)
                                .Include(s => s.Items)
                                .Where(s => s.User.Email == email)
                                .FirstOrDefault();

            if (shoppingCart == null)
            {
                throw new ResourceNotFoundException("Shopping cart not found for user");
            }
            shoppingCart.Items.Add(shoppingCartItem);
            _dbContext.SaveChanges();
        }

        public void RemoveCartItem(string email, int id)
        {
            var userCartItems = _dbContext.ShoppingCart.Include(s => s.User).Include(s => s.Items).Where(s => s.User.Email == email).FirstOrDefault();


            var item = userCartItems.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                throw new ResourceNotFoundException("Shopping cart item not found for user");
            }
            userCartItems.Items.Remove(item);
            _dbContext.SaveChanges();

        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            var userCart = _dbContext.ShoppingCart.Include(s => s.User).Include(s => s.Items).Where(s => s.User.Email == email).FirstOrDefault();

            var item = userCart.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new ResourceNotFoundException("Shopping cart item not found for user");
            }
            item.Quantity = quantity;
            _dbContext.SaveChanges();

        }

        public void ClearCart(string email)
        {
            var userCart = _dbContext.ShoppingCart.Include(s => s.User).Include(s => s.Items).Where(s => s.User.Email == email).FirstOrDefault();
            var cartItems = userCart.Items;
            foreach (var item in cartItems)
            {
                userCart.Items.Remove(item);
            }
            _dbContext.SaveChanges();
        }

        public void DeleteCart(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}