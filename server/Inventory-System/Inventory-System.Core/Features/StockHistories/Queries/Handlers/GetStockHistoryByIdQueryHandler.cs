using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.StockHistories.Queries.DTOs;
using Inventory_System.Core.Features.StockHistories.Queries.Models;
using Inventory_System.Service.Abstracts;
using MediatR;


namespace Inventory_System.Core.Features.StockHistories.Queries.Handlers
{
    public class GetStockHistoryByIdQueryHandler
        : IRequestHandler<GetStockHistoryByIdQuery, Result<StockHistoryDto>>
    {
        private readonly IStockHistoryService _stockHistoryService;
        private readonly IMapper _mapper;

        public GetStockHistoryByIdQueryHandler(IStockHistoryService stockHistoryService, IMapper mapper)
        {
            _stockHistoryService = stockHistoryService;
            _mapper = mapper;
        }

        public async Task<Result<StockHistoryDto>> Handle(
            GetStockHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var stockHistory = await _stockHistoryService.GetByIdAsync(request.Id);

            if (stockHistory == null)
                return Result<StockHistoryDto>.Failure("Stock History Not Found", ResultStatus.NotFound);

            var dto = _mapper.Map<StockHistoryDto>(stockHistory);
            return Result<StockHistoryDto>.Success(dto);
        }
    }
}