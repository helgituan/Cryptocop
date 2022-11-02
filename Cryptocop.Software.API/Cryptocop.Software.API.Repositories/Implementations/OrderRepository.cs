using System;
using System.Collections.Generic;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Cryptocop.Software.API.Models.Exceptions;
using Cryptocop.Software.API.Repositories.Helpers;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public OrderRepository(CryptocopDbContext dbContext, IMapper mapper, IShoppingCartRepository shoppingCartRepository)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public IEnumerable<OrderDto> GetOrders(string email)
        {
            var orders = _dbContext.User.Include(o => o.Orders).Where(u => u.Email == email).Select(o => o.Orders).FirstOrDefault();

            return _mapper.Map<IEnumerable<OrderDto>>(orders);

        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {

            var address = _dbContext.User.Include(u => u.Addresses).Where(u => u.Email == email).Select(u => u.Addresses.Where(a => a.Id == order.AddressId).FirstOrDefault()).FirstOrDefault();

            if (address == null)
            {
                throw new ResourceNotFoundException("The address was not found");
            }

            var card = _dbContext.User.Include(u => u.PaymentCards).Where(u => u.Email == email).Select(u => u.PaymentCards.Where(p => p.Id == order.PaymentCardId).FirstOrDefault()).FirstOrDefault();

            if (card == null)
            {
                throw new ResourceNotFoundException("The card was not found");
            }

            var userCart = _dbContext.ShoppingCart.Include(s => s.User).Include(s => s.Items).Where(s => s.User.Email == email).FirstOrDefault();

            var user = _dbContext.User.Where(u => u.Email == email).FirstOrDefault();

            var cartItems = userCart.Items;

            var newOrder = new Order
            {
                Email = email,
                FullName = user.FullName,
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                Country = address.Country,
                City = address.City,
                CardHolderName = card.CardHolderName,
                MaskedCreditCard = PaymentCardHelper.MaskPaymentCard(card.CardNumber),
                OrderDate = DateTime.Now,
                TotalPrice = userCart.Items.Sum(i => i.UnitPrice * i.Quantity),
                OrderItems = userCart.Items.Select(i => new OrderItem
                {
                    ProductIdentifier = i.ProductIdentifier,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    TotalPrice = i.Quantity * i.UnitPrice
                }).ToList()
                // OrderItems = userCart.Items.Select(i =>
                // {
                //     var item = _mapper.Map<OrderItem>(i);
                //     item.TotalPrice = item.Quantity * item.UnitPrice;
                //     return item;
                // }).ToList()
            };
            _dbContext.Order.Add(newOrder);
            _dbContext.SaveChanges();

            _shoppingCartRepository.ClearCart(email);

            return _mapper.Map<OrderDto>(newOrder);

        }
    }
}