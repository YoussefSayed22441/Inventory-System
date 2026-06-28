using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Users.Queries.DTOs
{
    public class UserListDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
