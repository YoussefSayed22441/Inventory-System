using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Commands.Models;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productService.GetByIdAsync(request.Id);
            if(existingProduct == null) 
                return Result<ProductDto>.Failure("Product Not Found", ResultStatus.NotFound);

            var existingCategory = await _categoryService.GetByIdAsync(request.CategoryId);
            if(existingCategory == null)
                return Result<ProductDto>.Failure("Category Not Found", ResultStatus.NotFound);
            
            _mapper.Map(request, existingProduct);

            var result = await _productService.UpdateAsync(existingProduct);
            if(result == null)
                return Result<ProductDto>.Failure("Product Update Failed", ResultStatus.ValidationError);

            var dto = _mapper.Map<ProductDto>(result);
            return Result<ProductDto>.Success(dto, "Product Updated Successfully");
        }
    }
}
