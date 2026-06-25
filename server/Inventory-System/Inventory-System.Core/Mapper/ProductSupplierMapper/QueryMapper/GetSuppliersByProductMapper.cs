using Inventory_System.Core.Features.ProductSupplier.Queries.DTOs;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ProductSupplierMapper
{
    public partial class ProductSupplierProfile
    {
        public void GetSuppliersByProductMapper()
        {
            CreateMap<ProductSupplier, SupplierOfProductDto>()
                .ForMember(dest => dest.SupplierName,
                    opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : string.Empty))
                .ForMember(dest => dest.SupplierEmail,
                    opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Email : string.Empty))
                .ForMember(dest => dest.SupplierPhone,
                    opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Phone : string.Empty));
        }
    }
}
