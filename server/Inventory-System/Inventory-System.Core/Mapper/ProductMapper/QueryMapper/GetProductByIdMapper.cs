using Inventory_System.Core.Features.Products.Queries.DTOs;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ProductMapper
{
    public partial class ProductProfile
    {
        public void GetProductByIdMapper()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName,
                   opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : string.Empty));
        }
    }
}
