using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Core.Features.Categories.Queries.Models;
using Inventory_System.Core.Wrapper;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Queries.Handles
{
    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<PaginatedResult<ProductDto>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<Result<PaginatedResult<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _productService.GetProducts();
            var totalCount = await query.CountAsync();

            var data = query
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) *request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var paginated = PaginatedResult<ProductDto>
                .Success(data,request.PageNumber,totalCount, request.PageSize);

            return Result<PaginatedResult<ProductDto>>.Success(paginated);

        }
    }
}
