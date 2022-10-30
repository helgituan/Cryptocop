using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Entities;
using AutoMapper;

namespace Cryptocop.Software.API.Repositories.Implementations
{

    public class UserRepository : IUserRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            var user = _mapper.Map<User>(inputModel);
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
                // Hvað á ég að gera við TokenId ?
            };
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            throw new NotImplementedException();
        }
    }
}