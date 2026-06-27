using Inventory_System.Core.Features.ProductSupplier.Queries.DTOs;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ProductSupplierMapper
{
    public partial class ProductSupplierProfile
    {
        public void GetProductsBySupplierMapper()
        {
            CreateMap<ProductSupplier, ProductOfSupplierDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : string.Empty))
                .ForMember(dest => dest.SKU,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.SKU : null))
                .ForMember(dest => dest.Barcode,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.Barcode : null))
                .ForMember(dest => dest.SellingPrice,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.SellingPrice : 0))
                .ForMember(dest => dest.CurrentStock,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.CurrentStock : 0))
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Product != null && src.Product.Category != null
                        ? src.Product.Category.CategoryName : string.Empty));

        }
    }
}
