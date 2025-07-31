using AutoMapper;
using Basket.BLL.Dto;
using Basket.BLL.Exceptions;
using Basket.BLL.Services.Interfaces;
using Basket.DAL.Models;
using Basket.DAL.Repositories.Interfaces;

namespace Basket.BLL.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<CustomerBasketDto> GetByCustomerIdAsync(Guid customerId)
        {
            var existingBasket = await _basketRepository.GetByCustomerIdAsync(customerId);

            if (existingBasket != null) 
            {
                return _mapper.Map<CustomerBasketDto>(existingBasket);
            }

            var basket = new CustomerBasketDb()
            {
                CustomerId = customerId,
                Items = new List<BasketItemDb>()
            };

            await _basketRepository.UpdateAsync(basket);

            return _mapper.Map<CustomerBasketDto>(basket);
        }

        public async Task<CustomerBasketDto> UpdateAsync(Guid customerId, CustomerBasketDto dto)
        {
            var existingBasket = await _basketRepository.GetByCustomerIdAsync(customerId);

            if (existingBasket != null) 
            {
                existingBasket.Items = MapItems(dto.Items);
                await _basketRepository.UpdateAsync(existingBasket);

                return _mapper.Map<CustomerBasketDto>(existingBasket);
            }

            var basket = new CustomerBasketDb()
            {
                CustomerId = customerId,
                Items = MapItems(dto.Items)
            };

            await _basketRepository.UpdateAsync(basket);

            return _mapper.Map<CustomerBasketDto>(basket);
        }

        public async Task DeleteAsync(Guid customerId)
        {
            var existingBasket = await _basketRepository.GetByCustomerIdAsync(customerId)
                ?? throw new BasketNotFoundException($"Basket with customer id: {customerId} not found.");

            await _basketRepository.DeleteAsync(customerId);
        }

        private List<BasketItemDb> MapItems(IEnumerable<BasketItemDto> items)
        {
            return items.Select(item => _mapper.Map<BasketItemDb>(item)).ToList();
        }
    }
}
