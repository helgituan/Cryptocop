using System.Collections.Generic;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Entities;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private CryptocopDBContext _dbContext;
        private readonly IMapper _mapper;
        public AddressRepository(CryptocopDBContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void AddAddress(string email, AddressInputModel address)
        {

            /*
            public string StreetName { get; set; }
            public string HouseNumber { get; set; }
            public string ZipCode { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            */
            // TODO: Emails?
            var address = new AddressInputModel
            {
                StreetName = InputModels.StreetName,
                HouseNumber = InputModels.HouseNumber,
                ZipCode = InputModels.ZipCode,
                Country = InputModels.Country,
                City = InputModels.City
            };
            _dbContext.Add(address);
            _dbContext.SaveChanges();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            var addresses = _mapper.Map<IEnumerable<AddressDto>>(_dbContext.Addresses);
            return addresses;
        }


        // TODO: Fixxxx this
        public void DeleteAddress(string email, int addressId)
        {
            var address = _dbContext.Addresses.Where(x => x.address).FirstOrDefault(a => p.addressId == addressId);
            if (address == null)
                throw new ExecutionError($"Address with id '{addressId}' was not found");
            //Delete Address
            _dbContext.SaveChanges();
            return address;
        }
    }
}