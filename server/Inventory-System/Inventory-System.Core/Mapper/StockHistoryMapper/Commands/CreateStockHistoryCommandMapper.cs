using Inventory_System.Core.Features.StockHistories.Commands.Models;
using Inventory_System.Domain.Entities;

namespace Inventory_System.Core.Mapper.StockHistoryMapper
{
    public partial class StockHistoryProfile
    {
        public void CreateStockHistoryCommandMapper()
        {
            CreateMap<CreateStockHistoryCommand, StockHistory>();
        }
    }
}