using System.Collections.Generic;
using NivelBasico.Domain.Models;

namespace NivelBasico.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        User Get(string document);
        void Add(User user);
        void Update(User user);
        void Delete(string document);
    }
}