using AutoMapper;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Entities;

namespace Cryptocop.Software.API.Profiles;

public class PaymentCardProfile : Profile
{
    public PaymentCardProfile()
    {
        CreateMap<PaymentCard, PaymentCardDto>();
        CreateMap<PaymentCardInputModel, PaymentCard>();
    }
}
