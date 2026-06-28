using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Users.Commands.Models;
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
    internal class DeleteCurrentUserHandler : IRequestHandler<DeleteCurrentUserCommand, Result<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteCurrentUserHandler(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<Result<string>> Handle(  DeleteCurrentUserCommand request,  CancellationToken cancellationToken)
        {
            // Get Current User
            var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return Result<string>.Failure( "Unauthorized",  ResultStatus.Unauthorized);

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return Result<string>.Failure("User not found", ResultStatus.NotFound);

            // Check Current Password
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)   return Result<string>.Failure("Current password is incorrect",  ResultStatus.ValidationError);

            // Delete User
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ",
                    result.Errors.Select(x => x.Description));

                return Result<string>.Failure(errors, ResultStatus.ValidationError);
            }

            return Result<string>.Success("Account deleted successfully.");
        }
    }
}
