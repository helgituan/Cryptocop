using System.Threading.Tasks;
using Cryptocop.Software.API.Models;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ExchangeService : IExchangeService
    {
        
        public Task<Envelope<ExchangeDto>> GetExchanges(int pageNumber = 1)
        {
            throw new System.NotImplementedException();
        }
    }
}