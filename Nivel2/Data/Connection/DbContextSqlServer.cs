using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Nivel2.Data.Connection
{
    public class DbContextSqlServer : DbContext, IDisposable
    {
        private const string CONNECTION_STRING_NAME = "db";
        private readonly IConfiguration _configuration; 
        public IDbConnection _connection;      
        public IDbTransaction _transaction;
        public string _connectionString = null;
        

        public DbContextSqlServer(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(CONNECTION_STRING_NAME); 
        }

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose(true);
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose(true);
        }

        public bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
                    _connection = null;

                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                    }
                    _transaction = null;
                }
            }
            this.disposed = true;
        }

        public override void Dispose()
        {
            if (_transaction != null && _connection.State == ConnectionState.Open)
            {
                _transaction.Commit();
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}