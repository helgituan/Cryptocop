using System.Collections.Generic;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Entities;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Models.Exceptions;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        public AddressRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void AddAddress(string email, AddressInputModel address)
        {
            var user = _dbContext.User.Include(u => u.Addresses).FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new ResourceNotFoundException("User not found");
            }
            var newAddress = _mapper.Map<Address>(address);
            user.Addresses.Add(newAddress);

            _dbContext.SaveChanges();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            return _dbContext.User.Include(u => u.Addresses).Where(u => u.Email == email).Select(u => u.Addresses.Select(a => _mapper.Map<AddressDto>(a))).FirstOrDefault();
            // return _dbContext.Address.Select(address => _mapper.Map<AddressDto>(address)).AsEnumerable();
        }

        public void DeleteAddress(string email, int addressId)
        {
            var user = _dbContext.User.Include(u => u.Addresses).FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new ResourceNotFoundException("User not found");
            }
            var address = user.Addresses.FirstOrDefault(a => a.Id == addressId);
            if (address == null)
            {
                throw new ResourceNotFoundException("Address not found");
            }
            _dbContext.Address.Remove(address);
            _dbContext.SaveChanges();
        }
    }
}