using Inventory_System.Core.Features.ProductSupplier.Commands.Models;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ProductSupplierMapper
{
    public partial class ProductSupplierProfile
    {
        public void AssignSupplierToProductCommandMapper()
        {
            CreateMap<AssignSupplierToProductCommand, ProductSupplier>();
        }
    }
}
