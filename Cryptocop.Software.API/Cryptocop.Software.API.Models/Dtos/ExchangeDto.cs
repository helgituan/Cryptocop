using System;
using System.Text.Json.Serialization;
namespace Cryptocop.Software.API.Models.Dtos
{
    public class ExchangeDto
    {
        [JsonPropertyName("Id")]
        public string id { get; set; }
        [JsonPropertyName("Name")]
        public string exchange_name { get; set; }
        [JsonPropertyName("Slug")]
        public string exchange_slug { get; set; }
        [JsonPropertyName("AssetSymbol")]
        public string base_asset_symbol { get; set; }
        [JsonPropertyName("PriceInUsd")]
        public float? price_usd { get; set; }
        [JsonPropertyName("LastTrade")]
        public DateTime? last_trade_at { get; set; }
    }
}