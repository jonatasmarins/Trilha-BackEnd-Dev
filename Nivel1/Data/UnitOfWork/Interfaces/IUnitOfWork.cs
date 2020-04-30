
using Nivel1.Data.Repositories.Interfaces;

namespace Nivel1.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}