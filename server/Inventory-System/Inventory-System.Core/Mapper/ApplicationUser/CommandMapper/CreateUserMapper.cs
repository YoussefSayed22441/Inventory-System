using AutoMapper;
using Inventory_System.Core.Features.Users.Commands.Models;

namespace Inventory_System.Core.Mapper.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void CreateUserMapper()
        {
            //        Source  ............ Dest
            CreateMap<RegisterUserCommand, Infrastructure.Identity.ApplicationUser>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
