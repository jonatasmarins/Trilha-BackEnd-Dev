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
        public IUserRepository UserRepository
        {
            get { return new UserRepository(_dataContext); }
        }
    }
}