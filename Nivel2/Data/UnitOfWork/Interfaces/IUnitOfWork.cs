
using System;
using System.Data;
using Nivel2.Data.Repositories.Interfaces;

namespace Nivel2.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        ICartRepository CartRepository { get; }
    }
}