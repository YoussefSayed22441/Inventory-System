using Inventory_System.Core.Features.Products.Commands.Models;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ProductMapper
{
    public partial class ProductProfile
    {
        public void UpdateProductCommandMapper()
        {
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}

