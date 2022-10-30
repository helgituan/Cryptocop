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
    public class PaymentRepository : IPaymentRepository
    {
        private CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;

        public void AddPaymentCard(string email, PaymentCardInputModel paymentCard)
        {
            /*
            _dbContext.Add(paymentCard);
            _dbContext.SaveChanges();
            return _mapper.Map<PaymentCardDto>(paymentCard);
            */
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}