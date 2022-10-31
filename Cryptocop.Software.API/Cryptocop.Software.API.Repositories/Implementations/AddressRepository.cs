using System.Collections.Generic;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Entities;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;
using System.Linq;
using System;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        public AddressRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void AddAddress(string email, AddressInputModel address)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Email == email);
            user.Addresses.Add(_mapper.Map<Address>(address));

            _dbContext.SaveChanges();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            return _dbContext.Address.Select(address => _mapper.Map<AddressDto>(address)).AsEnumerable();
        }


        // TODO: Fixxxx this
        public void DeleteAddress(string email, int addressId)
        {
            var address = _dbContext.Address.FirstOrDefault(a => a.Id == addressId);
            _dbContext.Address.Remove(address);
            _dbContext.SaveChanges();
        }
    }
}