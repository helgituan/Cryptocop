using AutoMapper;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Entities;

namespace Cryptocop.Software.API.Profiles;

public class ShoppingCartItemProfile : Profile
{
    public ShoppingCartItemProfile()
    {
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>();
        CreateMap<ShoppingCartItemInputModel, ShoppingCartItem>();
        CreateMap<ShoppingCartItem, OrderItem>();
    }
}
