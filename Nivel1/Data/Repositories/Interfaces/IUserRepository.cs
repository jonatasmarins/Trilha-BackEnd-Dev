using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel1.Domain.Models;

namespace Nivel1.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IList<User>> Get();
        Task<User> GetByDocument(string document);
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}