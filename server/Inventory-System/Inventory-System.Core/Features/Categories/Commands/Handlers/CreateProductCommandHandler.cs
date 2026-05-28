using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Commands.Models;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Domain.Entities;
using Inventory_System.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
public CreateProductCommandHandler(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Validate that the Category exists
            var categoryExists = await _categoryService.ExistsAsync(request.CategoryId);

            if (!categoryExists)
                return Result<ProductDto>.Failure("Category Not Found", ResultStatus.NotFound);

            var product = _mapper.Map<Product>(request);
            var result = await _productService.AddAsync(product);
            // Because AddAsync makes sure of the Uniqueness of the SKU 
            if (result == null)
                return Result<ProductDto>.Failure("A Product with this SKU already exists", ResultStatus.ValidationError);

            var dto = _mapper.Map<ProductDto>(result);
            return Result<ProductDto>.Created(dto, "Product Created Successfully");
        }
    }
}
