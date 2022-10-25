using System;
namespace Cryptocop.Software.API.Models.Dtos
{
    public class ExchangeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string AssetSymbol { get; set; }
        public float? PriceInUSD { get; set; }
        public DateTime? LastTrade { get; set; }
    }
}