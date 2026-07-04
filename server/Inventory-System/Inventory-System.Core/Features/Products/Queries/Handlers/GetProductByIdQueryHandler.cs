using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Products.Queries.DTOs;
using Inventory_System.Core.Features.Products.Queries.Models;
using Inventory_System.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Products.Queries.Handlers
{
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdWithIncludeAsync(request.Id);
            if(product == null) 
                return Result<ProductDto>.Failure("Product Not Found", ResultStatus.NotFound);

            var dto = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.Success(dto);
        }
    }
}
