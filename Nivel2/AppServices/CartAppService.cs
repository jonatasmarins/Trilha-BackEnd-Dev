using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel2.AppServices.Interfaces;
using Nivel2.Models.Requests;
using Nivel2.Models.Responses;
using Nivel2.Shared.Models.Interfaces;

namespace Nivel2.AppServices
{
    public class CartAppService : ICartAppService
    {
        public Task<IResultResponse> Add(CartItemAddRequest cart)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResultResponse<IList<CartResponse>>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<IResultResponse> RemoveItem(int ComicId, int UserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResultResponse> Update(CartItemUpdateRequest cart)
        {
            throw new System.NotImplementedException();
        }
    }
}