using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NivelBasico.Repositories.Interfaces.Connection
{
    public interface IConnection : IDisposable
    {
         SqlConnection GetConnection();
         void Execute(SqlCommand sqlCommand);
         SqlDataReader ExecuteReader(SqlCommand sqlCommand);
         Task<SqlDataReader> ExecuteReaderAsync(SqlCommand sqlCommand);
    }
}