using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Nivel2.Data.UnitOfWork.Interfaces;
using Nivel2.Domain.Models;
using Nivel2.Domain.Services.Interfaces;

namespace Nivel2.Domain.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CartService(
            IUnitOfWork uow,
            IMapper mapper
        )
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Add(Cart cart)
        {
            await _uow.CartRepository.Add(cart);
        }

        public async Task<IList<Cart>> Get()
        {
            return await _uow.CartRepository.Get();
        }

        public async Task RemoveItem(int ComicId, int UserId)
        {
            await _uow.CartRepository.RemoveItem(ComicId, UserId);
        }
    }
}