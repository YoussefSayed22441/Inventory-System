using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Users.Commands.Models;
using Inventory_System.Infrastructure.Identity;
using Inventory_System.Service.Abstracts;
using Inventory_System.Service.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Users.Commands.Handlers
{
    internal class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, Result<JWTAuthResult>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public RefreshTokenHandler(UserManager<ApplicationUser> userManager,
            IAuthenticationService authenticationService, IMapper mapper)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<Result<JWTAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _authenticationService.GetAccessTokenAfterExpirationByRefreshToken(request.AccessToken, request.RefreshToken);

                return Result<JWTAuthResult>.Success(result);
            }
            catch (SecurityTokenException ex)
            {
                return Result<JWTAuthResult>.Failure(ex.Message, ResultStatus.Unauthorized);
            }
        }



    }
}
