
using System.Threading.Tasks;
using Nivel1.Data.Repositories.Interfaces;

namespace Nivel1.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChange();
        IUserRepository UserRepository { get; }
        IComicRepository ComicRepository { get; }
        ICharacterRepository CharacterRepository { get; }
        ICreatorRepository CreatorRepository { get; }
        IComicCreatorRepository ComicCreatorRepository { get; }
        IComicCharacterRepository ComicCharacterRepository { get; }
    }
}