using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Users.Commands.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Core.Features.Users.Commands.Models
{
    public class LoginUserCommand : IRequest<Result<UserDto>>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
