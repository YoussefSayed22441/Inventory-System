using Inventory_System.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory_System.Core.Features.Users.Commands.Models
{
    public class DeleteCurrentUserCommand : IRequest<Result<string>>
    {
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
