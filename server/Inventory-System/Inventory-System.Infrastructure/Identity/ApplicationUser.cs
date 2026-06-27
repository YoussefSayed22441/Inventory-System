using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            RefreshTokens = new HashSet<UserRefreshToken>();
        }
        public string FullName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(UserRefreshToken.User))]
        public ICollection<UserRefreshToken> RefreshTokens { get; set; }
    }
}
