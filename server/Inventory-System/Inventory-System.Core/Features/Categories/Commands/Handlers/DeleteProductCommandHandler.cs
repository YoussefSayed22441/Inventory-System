using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Commands.Models;
using Inventory_System.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<bool>>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(request.Id);
            if(product == null) 
                return Result<bool>.Failure("Product Not Found", ResultStatus.NotFound);

            var result = await _productService.DeleteAsync(product);
            if(!result)
                return Result<bool>.Failure("Product Delete Failed", ResultStatus.ValidationError);

            return Result<bool>.Success(true, "Product Deleted Successfully");
        }
    }
}
