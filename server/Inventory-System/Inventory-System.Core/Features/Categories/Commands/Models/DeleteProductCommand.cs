using Inventory_System.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Models
{
    public class DeleteProductCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        
    }
}
