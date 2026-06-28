using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Users.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory_System.Core.Features.Users.Commands.Models
{
    public class UpdateUserCommand : IRequest<Result<UserListDto>>
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
