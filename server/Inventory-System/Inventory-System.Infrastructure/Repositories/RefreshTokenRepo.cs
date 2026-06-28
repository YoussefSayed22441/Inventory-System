using Inventory_System.Infrastructure.Data;
using Inventory_System.Infrastructure.Identity;
using Inventory_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Infrastructure.Repositories
{
    public class RefreshTokenRepo : GenericRepo<UserRefreshToken>, IRefreshTokenRepo
    {
        private readonly DbSet<UserRefreshToken> _refreshTokens;
        public RefreshTokenRepo(InventoryDbContext dbContext) : base(dbContext)
        {
            _refreshTokens = dbContext.Set<UserRefreshToken>();
        }
    }
}
