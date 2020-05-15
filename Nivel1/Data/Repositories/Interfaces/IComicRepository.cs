using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.Repositories.Interfaces
{
    public interface IComicRepository
    {
        Task<IList<Comic>> Get();
        Task<Comic> GetByCode(int comicID);
        Task Add(Comic Comic);
    }
}