﻿using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            //Hash password plox later xdd
            return _userRepository.CreateUser(inputModel);
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            throw new System.NotImplementedException();
        }

        public void Logout(int tokenId)
        {
            throw new System.NotImplementedException();
        }
    }
}