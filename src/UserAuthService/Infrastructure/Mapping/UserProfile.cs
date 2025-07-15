using AutoMapper;
using UserAuthService.Domain;

namespace UserAuthService.Infrastructure.Mapping;   // file‑scoped

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}

public record UserDto(Guid Id, string Email);
