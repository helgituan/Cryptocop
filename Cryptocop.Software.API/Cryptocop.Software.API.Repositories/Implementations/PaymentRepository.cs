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

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;

        public PaymentRepository(IMapper mapper, CryptocopDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void AddPaymentCard(string email, PaymentCardInputModel paymentCard)
        {
            var card = _mapper.Map<PaymentCard>(paymentCard);
            var user = _dbContext.User.Include(u => u.PaymentCards).Where(u => u.Email == email).FirstOrDefault();
            user.PaymentCards.Add(card);
            _dbContext.SaveChanges();
        }

        public IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email)
        {
            return _dbContext.User.Include(u => u.PaymentCards).Where(u => u.Email == email).Select(u => u.PaymentCards.Select(a => _mapper.Map<PaymentCardDto>(a))).FirstOrDefault();
        }
    }
}