using System.Collections.Generic;
using NivelBasico.Domain.Models;

namespace NivelBasico.Domain.Services.Interfaces
{
    public interface IUserService
    {
        IList<User> GetAll();
        User Get(string document);
        void Add(User user);
        void Update(string document);
        void Delete(string document);
    }
}