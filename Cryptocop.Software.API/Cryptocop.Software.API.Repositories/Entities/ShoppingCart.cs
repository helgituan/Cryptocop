using System.Collections.Generic;

namespace Cryptocop.Software.API.Repositories.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public ICollection<ShoppingCartItem> Items { get; set; }
    public User User { get; set; }
}