using System;
using System.Data.SqlClient;

namespace NivelBasico.Repositories.Interfaces.Connection
{
    public interface IConnection : IDisposable
    {
         SqlConnection GetConnection();
         void Execute(SqlCommand sqlCommand);
         SqlDataReader ExecuteReader(SqlCommand sqlCommand);
    }
}