using System;
using System.Collections.Generic;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Entities;
using AutoMapper;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public IEnumerable<OrderDto> GetOrders(string email)
        {
            var orders = _mapper.Map<IEnumerable<OrderDto>>(_dbContext.Order);
            return orders;
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {

            _dbContext.Add(order);
            _dbContext.SaveChanges();
            return _mapper.Map<OrderDto>(order);

        }
    }
}