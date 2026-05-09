using AutoMapper;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.CategoryMapper
{
    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            GetCategoryByIdMapper();


            CreateCategoryCommandMapper();
            UpdateCategoryCommandMapper();

        }
    }
}
