using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Service.Models
{
    public class JWTAuthResult
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
    public class RefreshToken
    {
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
