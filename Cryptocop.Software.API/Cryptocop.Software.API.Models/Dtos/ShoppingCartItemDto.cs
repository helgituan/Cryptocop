namespace Cryptocop.Software.API.Models.Dtos
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }

        public string ProductIDentifier { get; set; }
        public float Quantity { get; set; }
        public float UnitPrie { get; set; }
        public float TotalPrice { get; set; }
        
    }
}