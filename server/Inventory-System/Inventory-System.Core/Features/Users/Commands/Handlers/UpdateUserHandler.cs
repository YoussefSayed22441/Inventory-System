using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Users.Commands.Models;
using Inventory_System.Core.Features.Users.Queries.DTOs;
using Inventory_System.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Inventory_System.Core.Features.Users.Commands.Handlers
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<UserListDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateUserHandler(IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        public async Task<Result<UserListDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Get Current User
            var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return Result<UserListDto>.Failure("Unauthorized", ResultStatus.Unauthorized);

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return Result<UserListDto>.Failure("User Not Found", ResultStatus.NotFound);

            // Check Username
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null && existingUser.Id != user.Id)
                return Result<UserListDto>.Failure( "Username already exists", ResultStatus.ValidationError);

            // Update User
            _mapper.Map(request, user);

            // Normalize Username
            user.NormalizedUserName = _userManager.NormalizeName(user.UserName);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return Result<UserListDto>.Failure(errors, ResultStatus.ValidationError);
            }

            var userDto = _mapper.Map<UserListDto>(user);
            return Result<UserListDto>.Success(userDto);

        }
    }
}
