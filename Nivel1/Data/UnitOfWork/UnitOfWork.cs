using System.Threading.Tasks;
using Nivel1.Data.Context;
using Nivel1.Data.Repositories;
using Nivel1.Data.Repositories.Interfaces;
using Nivel1.Data.UnitOfWork.Interfaces;

namespace Nivel1.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SaveChange()
        {
            await _dataContext.SaveChangesAsync();
        }

        public IUserRepository UserRepository
        {
            get { return new UserRepository(_dataContext); }
        }

        public IComicRepository ComicRepository
        {
            get { return new ComicRepository(_dataContext); }
        }

        public ICharacterRepository CharacterRepository
        {
            get { return new CharacterRepository(_dataContext); }
        }

        public ICreatorRepository CreatorRepository
        {
            get { return new CreatorRepository(_dataContext); }
        }

        public IComicCreatorRepository ComicCreatorRepository
        {
            get { return new ComicCreatorRepository(_dataContext); }
        }

        public IComicCharacterRepository ComicCharacterRepository
        {
            get { return new ComicCharacterRepository(_dataContext); }
        }
    }
}