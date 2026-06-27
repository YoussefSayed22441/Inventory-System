using Inventory_System.Core.Features.StockHistories.Queries.DTOs;
using Inventory_System.Domain.Entities;

namespace Inventory_System.Core.Mapper.StockHistoryMapper
{
    public partial class StockHistoryProfile
    {
        public void GetStockHistoryByIdMapper()
        {
            //        Source          Dest
            CreateMap<StockHistory, StockHistoryDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : null))
                .ForMember(dest => dest.SupplierName,
                    opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : null));
        }
    }
}