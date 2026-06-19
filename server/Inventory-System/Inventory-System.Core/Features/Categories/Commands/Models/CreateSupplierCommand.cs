using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Models
{
    public class CreateSupplierCommand : IRequest<Result<SupplierDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Temporary default — replace with authenticated user once JWT/Auth is implemented
        public string CreatedBy { get; set; } = "System";
    }
}
