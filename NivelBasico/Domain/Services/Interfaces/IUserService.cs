using System.Collections.Generic;
using NivelBasico.Domain.Models;

namespace NivelBasico.Domain.Services.Interfaces
{
    public interface IUserService
    {
        void GetAll();
         void Get(string cpf);
         void Add(User cliente);
         void Update(string cpf);
         void Delete(string cpf);
    }
}