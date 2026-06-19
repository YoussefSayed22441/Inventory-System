using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ProductMapper
{
    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {
            GetProductByIdMapper();
            CreateProductCommandMapper();
            UpdateProductCommandMapper();
        }
    }
}
