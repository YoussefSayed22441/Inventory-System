using Inventory_System.Core.Features.ProductSupplier.Queries.DTOs;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ProductSupplierMapper
{
    public partial class ProductSupplierProfile
    {
        public void GetProductSupplierByIdsMapper()
        {
            CreateMap<ProductSupplier, ProductSupplierDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : string.Empty))
                .ForMember(dest => dest.SupplierName,
                    opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : string.Empty));
        }
    }
}
