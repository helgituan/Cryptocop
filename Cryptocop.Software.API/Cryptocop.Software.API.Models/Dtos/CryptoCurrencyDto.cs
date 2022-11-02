using System.Text.Json.Serialization;

namespace Cryptocop.Software.API.Models.Dtos
{
    public class CryptoCurrencyDto
    {
        [JsonPropertyName("Id")]
        public string id { get; set; }
        [JsonPropertyName("Symbol")]
        public string symbol { get; set; }
        [JsonPropertyName("Name")]
        public string name { get; set; }
        [JsonPropertyName("Slug")]
        public string slug { get; set; }
        [JsonPropertyName("PriceInUsd")]
        public float price_usd { get; set; }
        [JsonPropertyName("ProjectDetails")]
        public string project_details { get; set; }
    }
}