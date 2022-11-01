using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Entities;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;
using System.Linq;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class TokenRepository : ITokenRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;

        public TokenRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public JwtTokenDto CreateNewToken()
        {
            throw new System.NotImplementedException();
        }

        public bool IsTokenBlacklisted(int tokenId)
        {
            var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
            if (token == null) { return true; }
            return token.Blacklisted;
        }

        public void VoidToken(int tokenId)
        {
            throw new System.NotImplementedException();
        }
    }
}