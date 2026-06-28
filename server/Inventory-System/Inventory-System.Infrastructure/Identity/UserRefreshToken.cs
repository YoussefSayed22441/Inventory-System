using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Infrastructure.Identity
{
    public class UserRefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsExpired => DateTime.UtcNow > ExpiresOn;
        public DateTime CreatedOn { get; set; }

        // RevoCation
        public bool IsRevoked { get; set; }
        public DateTime? RevokedOn { get; set; }

        #region Relation With User
        public string UserId { get; set; } // Foreign key

        [InverseProperty(nameof(ApplicationUser.RefreshTokens))]
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } // Navigational property
        #endregion

    }
}
