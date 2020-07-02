using System.Collections.Generic;
using System.Threading.Tasks;
using NivelBasico.Domain.Models;

namespace NivelBasico.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IList<User>> GetAllAsync();
        IList<User> GetAll();
        User Get(string document);
        void Add(User user);
        void Update(User user);
        void Delete(string document);
    }
}