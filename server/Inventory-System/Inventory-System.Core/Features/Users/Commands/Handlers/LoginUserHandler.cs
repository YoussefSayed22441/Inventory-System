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
    internal class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<UserDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public LoginUserHandler(UserManager<ApplicationUser> userManager,
            IAuthenticationService authenticationService, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<Result<UserDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return Result<UserDto>.Failure("Invalid Email or Password", ResultStatus.Unauthorized);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
            if (result.IsLockedOut)
                return Result<UserDto>.Failure("Account is locked. Try again later.", ResultStatus.Unauthorized);

            if (!result.Succeeded)
                return Result<UserDto>.Failure("Invalid Email or Password", ResultStatus.Unauthorized);

            var jwtAuthResult = await _authenticationService.GetJWTTokenANDRefreshToken(user);
            var userDto = _mapper.Map<UserDto>(user);
            userDto.jWTAuth = jwtAuthResult;

            return Result<UserDto>.Success(userDto);
        }
    }
}
