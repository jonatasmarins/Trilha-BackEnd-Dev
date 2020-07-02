using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel2.Domain.Models;

namespace Nivel2.Data.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<IList<Cart>> Get();
        Task Add(Cart cart);
        Task RemoveItem(int ComicId, int UserId);
    }
}