using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel2.Domain.Models;
using Nivel2.Models.Requests;
using Nivel2.Models.Responses;
using Nivel2.Shared.Models.Interfaces;

namespace Nivel2.AppServices.Interfaces
{
    public interface ICartAppService
    {
        Task<IResultResponse<IList<CartResponse>>> Get(int CartId);
        Task<IResultResponse<IList<CartResponse>>> GetAll();
        Task<IResultResponse> Add(CartItemAddRequest cart);
        Task<IResultResponse> Update(CartItemUpdateRequest cart);
        Task<IResultResponse> RemoveItem(int ComicId, int UserId);
    }
}