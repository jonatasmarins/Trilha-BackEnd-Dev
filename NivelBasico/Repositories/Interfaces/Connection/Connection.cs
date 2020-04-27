using System;
using System.Data;
using System.Data.SqlClient;

namespace NivelBasico.Repositories.Interfaces.Connection
{
    public class Connection : IConnection, IDisposable
    {
        public readonly string _connectionString = "Server=localhost,1401;Database=mydatabase;User Id=sa;Password=Teste1234;";
        private SqlConnection _connection { get; set;}

        public Connection()
        {
            _connection = new SqlConnection(_connectionString);
            Open();
        }

        private void Open()
        {
            _connection.Open();
        }

        public SqlConnection GetConnection() {
            return _connection;
        }

        public void Execute(SqlCommand sqlCommand)
        {
            sqlCommand.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(SqlCommand sqlCommand)
        {
            return sqlCommand.ExecuteReader();
        }

        public void Dispose()
        {
            _connection.Dispose();
            GC.SuppressFinalize(_connection);
        }
    }
}