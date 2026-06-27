using AutoMapper;
using Inventory_System.Core.Features.Users.Commands.DTOs;

namespace Inventory_System.Core.Mapper.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateUserMapper();
          
            CreateMap<Inventory_System.Infrastructure.Identity.ApplicationUser, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
