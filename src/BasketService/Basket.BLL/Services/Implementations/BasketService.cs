using AutoMapper;
using Basket.BLL.DTOs;
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

        public async Task<BasketDTO> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            var existingBasket = await _basketRepository.GetByCustomerIdAsync(customerId, cancellationToken);

            if (existingBasket != null) 
            {
                return _mapper.Map<BasketDTO>(existingBasket);
            }

            var basket = new BasketDb()
            {
                CustomerId = customerId,
                BasketItems = new List<BasketItemDb>()
            };

            await _basketRepository.UpdateAsync(basket, cancellationToken);

            return _mapper.Map<BasketDTO>(basket);
        }


        public async Task<BasketDTO> UpdateAsync(Guid customerId, BasketDTO dto, CancellationToken cancellationToken)
        {
            var existingBasket = await _basketRepository.GetByCustomerIdAsync(customerId, cancellationToken);

            if (existingBasket != null) 
            {
                existingBasket.BasketItems = MapItems(dto.BasketItems);
                await _basketRepository.UpdateAsync(existingBasket, cancellationToken);

                return _mapper.Map<BasketDTO>(existingBasket);
            }

            var basket = new BasketDb()
            {
                CustomerId = customerId,
                BasketItems = MapItems(dto.BasketItems)
            };

            await _basketRepository.UpdateAsync(basket, cancellationToken);

            return _mapper.Map<BasketDTO>(basket);
        }


        public async Task DeleteAsync(Guid customerId, CancellationToken cancellationToken)
        {
            var existingBasket = await _basketRepository.GetByCustomerIdAsync(customerId, cancellationToken)
                ?? throw new BasketNotFoundException($"Basket with customer id: {customerId} not found.");

            await _basketRepository.DeleteAsync(customerId, cancellationToken);
        }


        private List<BasketItemDb> MapItems(IEnumerable<BasketItemDTO> basketItems)
        {
            return basketItems.Select(item => _mapper.Map<BasketItemDb>(item)).ToList();
        }
    }
}
