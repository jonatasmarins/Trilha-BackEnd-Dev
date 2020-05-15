using System.Threading.Tasks;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        Task Add(Character character);
        Task<Character> GetByCode(int Code);
        Task<int> GetIdByCode(int Code);
    }
}