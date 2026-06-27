using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Data;
using Inventory_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System.Infrastructure.Repositories;

public class StockHistoryRepo : GenericRepo<StockHistory>, IStockHistoryRepo
{
    private readonly DbSet<StockHistory> _stockHistories;
 
    public StockHistoryRepo(InventoryDbContext dbContext) : base(dbContext)
    {
        _stockHistories = dbContext.Set<StockHistory>();
    }
}