using System.Threading.Tasks;
using Cryptocop.Software.API.Models;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Repositories.Interfaces;
using System.Net.Http;
using System.Collections.Generic;
using Cryptocop.Software.API.Services.Helpers;
using System.Linq;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ExchangeService : IExchangeService
    {
        private readonly HttpClient _httpClient;

        public ExchangeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Envelope<ExchangeDto>> GetExchanges(int pageNumber = 1)
        {

            var envelope = new Envelope<ExchangeDto>();

            var response = await _httpClient.GetAsync($"api/v1/markets?page={pageNumber}&fields=id,exchange_name,exchange_slug,base_asset_symbol,price_usd,last_trade_at");
            var items = await response.DeserializeJsonToList<ExchangeDto>();

            envelope.PageNumber = pageNumber;
            envelope.Items = items;
            return envelope;
        }
    }
}