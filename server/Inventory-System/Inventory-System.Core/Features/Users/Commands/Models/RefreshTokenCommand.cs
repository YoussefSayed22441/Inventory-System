using Inventory_System.Core.Bases;
using Inventory_System.Service.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Users.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Result<JWTAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
