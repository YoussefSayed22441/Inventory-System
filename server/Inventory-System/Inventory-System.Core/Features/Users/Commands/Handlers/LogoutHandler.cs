using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Users.Commands.Models;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Users.Commands.Handlers
{
    internal class LogoutHandler : IRequestHandler<LogoutCommand, Result<string>>
    {
        private readonly IAuthenticationService _authenticationService;

        public LogoutHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<string>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isLoggedOut = await _authenticationService.RevokeUserRefreshTokensAsync(request.AccessToken, request.RefreshToken);
                if (!isLoggedOut)
                    return Result<string>.Failure("No active sessions found", ResultStatus.NotFound);

                return Result<string>.Success("Logged out successfully");
            }
            catch (SecurityTokenException ex)
            {
                return Result<string>.Failure(ex.Message, ResultStatus.Unauthorized);
            }
        }
    }
}
