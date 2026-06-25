using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ProductSupplierMapper
{
    public partial class ProductSupplierProfile : Profile
    {
        public ProductSupplierProfile()
        {
            GetSuppliersByProductMapper();
            GetProductsBySupplierMapper();
            GetProductSupplierByIdsMapper();
            AssignSupplierToProductCommandMapper();
        }
    }
}
