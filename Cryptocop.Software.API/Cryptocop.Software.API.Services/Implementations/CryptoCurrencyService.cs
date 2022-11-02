using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private readonly HttpClient _httpClient;

        public CryptoCurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
            ICollection<CryptoCurrencyDto> cryptoCurrencies = new List<CryptoCurrencyDto>();

            // Get btc
            var btcApiResults = await _httpClient.GetAsync("api/v1/assets/btc/metrics/market-data?fields=Asset/id,Asset/symbol,Asset/name,Asset/slug,market_data/price_usd");

            var btc = await btcApiResults.DeserializeJsonToObject<CryptoCurrencyDto>(flatten: true);

            var btcProject = await _httpClient.GetAsync($"api/v2/assets/btc/profile?fields=profile/general/overview/project_details");
            var btcProjectDeserialized = await btcProject.DeserializeJsonToObject<CryptoCurrencyDto>(flatten: true);

            btc.project_details = btcProjectDeserialized.project_details;

            cryptoCurrencies.Add(btc);
            // Get eth
            var ethApiResults = await _httpClient.GetAsync("api/v1/assets/eth/metrics/market-data?fields=Asset/id,Asset/symbol,Asset/name,Asset/slug,market_data/price_usd");

            var eth = await ethApiResults.DeserializeJsonToObject<CryptoCurrencyDto>(flatten: true);

            var ethProject = await _httpClient.GetAsync($"api/v2/assets/eth/profile?fields=profile/general/overview/project_details");
            var ethProjectDeserialized = await ethProject.DeserializeJsonToObject<CryptoCurrencyDto>(flatten: true);

            eth.project_details = ethProjectDeserialized.project_details;

            cryptoCurrencies.Add(eth);

            // Get USDT
            var USDTApiResults = await _httpClient.GetAsync("api/v1/assets/USDT/metrics/market-data?fields=Asset/id,Asset/symbol,Asset/name,Asset/slug,market_data/price_usd");

            var USDT = await USDTApiResults.DeserializeJsonToObject<CryptoCurrencyDto>(flatten: true);

            var USDTProject = await _httpClient.GetAsync($"api/v2/assets/USDT/profile?fields=profile/general/overview/project_details");
            var USDTProjectDeserialized = await USDTProject.DeserializeJsonToObject<CryptoCurrencyDto>(flatten: true);

            USDT.project_details = USDTProjectDeserialized.project_details;

            cryptoCurrencies.Add(USDT);

            // Get XMR
            var XMRApiResults = await _httpClient.GetAsync("api/v1/assets/XMR/metrics/market-data?fields=Asset/id,Asset/symbol,Asset/name,Asset/slug,market_data/price_usd");

            var XMR = await XMRApiResults.DeserializeJsonToObject<CryptoCurrencyDto>(flatten: true);

            var XMRProject = await _httpClient.GetAsync($"api/v2/assets/XMR/profile?fields=profile/general/overview/project_details");
            var XMRProjectDeserialized = await XMRProject.DeserializeJsonToObject<CryptoCurrencyDto>(flatten: true);

            XMR.project_details = XMRProjectDeserialized.project_details;

            cryptoCurrencies.Add(XMR);

            return cryptoCurrencies;
        }
    }
}