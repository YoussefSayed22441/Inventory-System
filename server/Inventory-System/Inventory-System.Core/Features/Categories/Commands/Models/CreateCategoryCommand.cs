using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Models
{
    public class CreateCategoryCommand : IRequest<Result<CategoryDto>>
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        //I added a temporary default value for CreatedBy because the column is NOT NULL in the database. We can later replace it with the authenticated user once JWT/Auth is implemented.
        public string CreatedBy { get; set; } = "System";
    }
}
