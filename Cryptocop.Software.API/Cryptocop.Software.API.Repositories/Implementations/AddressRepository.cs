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
            // var address = _dbContext.Address.FirstOrDefault(address => address.Email == email);

            _dbContext.SaveChanges();


        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            throw new NotImplementedException();
            /*
            var addresses = _mapper.Map<IEnumerable<AddressDto>>(_dbContext.Addresses);
            return addresses;
            */
        }


        // TODO: Fixxxx this
        public void DeleteAddress(string email, int addressId)
        {
            throw new NotImplementedException();
            /*
            var address = _dbContext.Addresses.Where(x => x.address).FirstOrDefault(a => p.addressId == addressId);
            if (address == null)
                throw new ExecutionError($"Address with id '{addressId}' was not found");
            //Delete Address
            _dbContext.SaveChanges();
            return address;
            */
        }
    }
}