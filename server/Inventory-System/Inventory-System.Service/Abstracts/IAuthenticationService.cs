using Inventory_System.Infrastructure.Identity;
using Inventory_System.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JWTAuthResult> GetJWTTokenANDRefreshToken(ApplicationUser user);
        public Task<JWTAuthResult> GetAccessTokenAfterExpirationByRefreshToken(string accessToken, string refreshToken);
        public Task<bool> RevokeUserRefreshTokens(string accessToken, string refreshToken);

    }
}
