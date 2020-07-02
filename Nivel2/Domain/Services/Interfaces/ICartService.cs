using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel2.Domain.Models;

namespace Nivel2.Domain.Services.Interfaces
{
    public interface ICartService
    {
        Task<IList<Cart>> Get();
        Task Add(Cart cart);
        Task RemoveItem(int ComicId, int UserId);
    }
}