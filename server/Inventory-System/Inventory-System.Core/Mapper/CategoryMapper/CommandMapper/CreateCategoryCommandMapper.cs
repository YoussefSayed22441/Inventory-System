using Inventory_System.Core.Features.Categories.Commands.Models;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.CategoryMapper
{
    public partial class CategoryProfile
    {
        public void CreateCategoryCommandMapper()
        {
            CreateMap<CreateCategoryCommand, Category>();
        }
    }
}
