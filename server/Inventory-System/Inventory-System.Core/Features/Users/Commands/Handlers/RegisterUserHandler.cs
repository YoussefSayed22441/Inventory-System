using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Users.Commands.DTOs;
using Inventory_System.Core.Features.Users.Commands.Models;
using Inventory_System.Infrastructure.Identity;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Inventory_System.Core.Features.Users.Commands.Handlers
{
    internal class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserHandler(IMapper mapper, UserManager<ApplicationUser> userManager, IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<Result<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userByEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userByEmail != null)
                return Result<UserDto>.Failure("this User already Exist", ResultStatus.ValidationError);

            var userByUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userByUserName != null)
                return Result<UserDto>.Failure("this UserName already Exist", ResultStatus.ValidationError);

            var identityUser = _mapper.Map<ApplicationUser>(request);
            var result = await _userManager.CreateAsync(identityUser, request.Password);
            if (!result.Succeeded)
                return Result<UserDto>.Failure("Failed in Create User", ResultStatus.ValidationError);

            var roleResult = await _userManager.AddToRoleAsync(identityUser, "User");
            if (!roleResult.Succeeded)
                return Result<UserDto>.Failure("Failed in Assign Role", ResultStatus.ValidationError);

            var jwtAuthResult = await _authenticationService.GetJWTTokenANDRefreshToken(identityUser);
            var userDto = _mapper.Map<UserDto>(identityUser);
            userDto.jWTAuth = jwtAuthResult;

            return Result<UserDto>.Success(userDto);
        }
    }
}
