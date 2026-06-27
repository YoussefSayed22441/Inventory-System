using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Users.Commands.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Core.Features.Users.Commands.Models
{
    public class RegisterUserCommand : IRequest<Result<UserDto>>
    {

        [Required]
        public string DisplayName { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d]).{8,}$", ErrorMessage = "Password must contain Uppercase, Lowercase, Digit and Special Character")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must match")]
        public string ConfirmPassword { get; set; }
    }
}
