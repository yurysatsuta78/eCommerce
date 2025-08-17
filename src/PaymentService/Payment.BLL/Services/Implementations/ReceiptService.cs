using AutoMapper;
using Payment.BLL.DTOs.ReceiptDTOs;
using Payment.BLL.Exceptions;
using Payment.BLL.Services.Interfaces;
using Payment.DAL.QueryParams;
using Payment.DAL.Repositories.Interfaces;

namespace Payment.BLL.Services.Implementations
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IMapper _mapper;

        public ReceiptService(IReceiptRepository receiptRepository, IMapper mapper)
        {
            _receiptRepository = receiptRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedReceipts> GetFilteredAsync(GetFilteredReceiptsDTO dto, CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<ReceiptQueryParams>(dto);

            var dataTask = _receiptRepository.GetFilteredAsync(queryParams, cancellationToken);
            var countTask = _receiptRepository.GetCountAsync(queryParams, cancellationToken);

            var receiptDtos = _mapper.Map<IEnumerable<ReceiptDTO>>(await dataTask);
            return new PaginatedReceipts(receiptDtos, await countTask, queryParams.PageNumber, queryParams.PageSize);
        }

        public async Task<ReceiptDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var receipt = await _receiptRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new ReceiptNotFoundException($"Receipt with id: {id} not found.");

            var receiptDto = _mapper.Map<ReceiptDTO>(receipt);

            return receiptDto;
        }
    }
}
