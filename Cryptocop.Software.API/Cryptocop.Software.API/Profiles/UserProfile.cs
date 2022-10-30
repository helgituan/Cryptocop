using AutoMapper;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Repositories.Entities;

namespace Cryptocop.Software.API.Profiles;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserInputModel,User>();
    }
}