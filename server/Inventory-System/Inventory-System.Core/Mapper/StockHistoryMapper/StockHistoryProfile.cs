using AutoMapper;

namespace Inventory_System.Core.Mapper.StockHistoryMapper
{
    public partial class StockHistoryProfile : Profile
    {
        public StockHistoryProfile()
        {
            GetStockHistoryByIdMapper();
            CreateStockHistoryCommandMapper();
        }
    }
}