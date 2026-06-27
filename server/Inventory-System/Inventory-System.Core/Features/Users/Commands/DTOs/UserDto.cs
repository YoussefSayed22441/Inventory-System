using Inventory_System.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Users.Commands.DTOs
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public JWTAuthResult jWTAuth { get; set; }

    }
}
