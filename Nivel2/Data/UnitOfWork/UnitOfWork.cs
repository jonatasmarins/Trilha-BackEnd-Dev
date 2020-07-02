using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nivel2.Data.Connection;
using Nivel2.Data.Repositories;
using Nivel2.Data.Repositories.Interfaces;
using Nivel2.Data.UnitOfWork.Interfaces;

namespace Nivel2.Data.UnitOfWork
{
    public class UnitOfWork : DbContextSqlServer, IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        public IDbConnection Connection { get { return _connection; } }
        public IDbTransaction Transaction { get { return _transaction; } }

        public UnitOfWork(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            Create();
        }

        public IUnitOfWork Create()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
                Begin();
                disposed = false;
            }

            return this;
        }

        #region Repositories

        public ICartRepository CartRepository { get { return new CartRepository(this); } }

        #endregion

    }
}