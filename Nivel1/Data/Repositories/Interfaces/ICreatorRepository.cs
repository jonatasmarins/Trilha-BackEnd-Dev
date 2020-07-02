using System.Threading.Tasks;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.Repositories.Interfaces
{
    public interface ICreatorRepository
    {
        Task Add(Creator Creator);
        Task<int> GetIdByCode(int Code);
        Task<Creator> GetByCode(int Code);
    }
}