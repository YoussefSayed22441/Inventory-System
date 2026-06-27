using Inventory_System.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Infrastructure.Interfaces
{
    public interface IRefreshTokenRepo : IGenericRepo<UserRefreshToken>
    {
    }
}
