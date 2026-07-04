using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Products.Queries.DTOs;
using Inventory_System.Core.Features.Products.Queries.Models;
using Inventory_System.Core.Wrapper;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Products.Queries.Handlers
{
    internal class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, Result<PaginatedResult<ProductDto>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductsByCategoryQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<Result<PaginatedResult<ProductDto>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var query = _productService.GetProductsByCategoryId(request.CategoryId);
            var totalCount = await query.CountAsync();

            var data = query
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var paginated = PaginatedResult<ProductDto>
                .Success(data, request.PageNumber, totalCount, request.PageSize);
            
            return Result<PaginatedResult<ProductDto>>.Success(paginated);
        }
    }
}
