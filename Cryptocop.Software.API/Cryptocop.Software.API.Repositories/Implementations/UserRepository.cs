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
using Cryptocop.Software.API.Repositories.Helpers;
using Cryptocop.Software.API.Models.Exceptions;

namespace Cryptocop.Software.API.Repositories.Implementations
{

    public class UserRepository : IUserRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        private string _salt = "00209b47-08d7-475d-a0fb-20abf0872ba0";
        public UserRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            if (_dbContext.User.Any(u => u.Email == inputModel.Email)) throw new EmailAlreadyExistsException();

            var user = _mapper.Map<User>(inputModel);
            user.HashedPassword = HashingHelper.HashPassword(inputModel.Password);
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();

            var shoppingCart = new ShoppingCart
            {
                User = user
            };

            _dbContext.ShoppingCart.Add(shoppingCart);
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
            var user = _dbContext.User.FirstOrDefault(u => u.Email == loginInputModel.Email && u.HashedPassword == HashingHelper.HashPassword(loginInputModel.Password)); //&& u.HashedPassword == HashPassword(loginInputModel.Password));
            if (user == null) return null;

            var token = new JwtToken();
            _dbContext.JwtTokens.Add(token);
            _dbContext.SaveChanges();

            var returnUser = _mapper.Map<UserDto>(user);
            returnUser.TokenId = token.Id;

            return returnUser;
        }
    }
}