using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using NivelBasico.Domain.Models;
using NivelBasico.Domain.ValuesObject;
using NivelBasico.Repositories.Interfaces;
using NivelBasico.Repositories.Interfaces.Connection;

namespace NivelBasico.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IConnection _connection;
        private const string QUERY_GET_ALL = @"SELECT * FROM users";

        public void Add(User user)
        {
            using (_connection = new Connection())
            {
                string queryString = @"INSERT INTO users VALUES(@name, @yearsOld, @document, @email, @phone, @address)";

                SqlCommand sqlCommand = new SqlCommand(queryString, _connection.GetConnection());
                sqlCommand.Parameters.AddWithValue("@name", user.GetName().ToString());
                sqlCommand.Parameters.AddWithValue("@yearsOld", user.GetYearsOld().ToString());
                sqlCommand.Parameters.AddWithValue("@document", user.GetDocumentNumber().ToString());
                sqlCommand.Parameters.AddWithValue("@email", user.GetEmail().ToString());
                sqlCommand.Parameters.AddWithValue("@phone", user.GetPhone().ToString());
                sqlCommand.Parameters.AddWithValue("@address", user.GetAddress());

                _connection.Execute(sqlCommand);
            }
        }

        public void Delete(string document)
        {
            using (_connection = new Connection())
            {
                string queryString = @"DELETE FROM users WHERE document = @document";

                SqlCommand sqlCommand = new SqlCommand(queryString, _connection.GetConnection());
                sqlCommand.Parameters.AddWithValue("@document", document);

                _connection.Execute(sqlCommand);
            }
        }

        public User Get(string document)
        {
            User user = null;

            using (_connection = new Connection())
            {
                string queryString = @"SELECT * FROM users WHERE document = @document";

                SqlCommand sqlCommand = new SqlCommand(queryString, _connection.GetConnection());
                sqlCommand.Parameters.AddWithValue("@document", document);

                SqlDataReader reader = _connection.ExecuteReader(sqlCommand);
                while (reader.Read())
                {
                    user = new User(
                        new Name(reader.GetString(reader.GetOrdinal("name"))),
                        new YearsOld(reader.GetString(reader.GetOrdinal("yearsOld"))),
                        new Cpf(reader.GetString(reader.GetOrdinal("document"))),
                        new Email(reader.GetString(reader.GetOrdinal("email"))),
                        new Phone(reader.GetString(reader.GetOrdinal("phone"))),
                        reader.GetString(reader.GetOrdinal("address"))
                    );
                }
            }

            return user;
        }

        public IList<User> GetAll()
        {
            IList<User> users = new List<User>();

            using (_connection = new Connection())
            {
                SqlCommand sqlCommand = new SqlCommand(QUERY_GET_ALL, _connection.GetConnection());
                SqlDataReader reader = _connection.ExecuteReader(sqlCommand);
                
                while (reader.Read())
                {
                    User user = ReadUserSqlCommand(reader);
                    users.Add(user);
                }
            }

            return users;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            IList<User> users = new List<User>();

            using (_connection = new Connection())
            {
                SqlCommand sqlCommand = new SqlCommand(QUERY_GET_ALL, _connection.GetConnection());
                SqlDataReader reader = await _connection.ExecuteReaderAsync(sqlCommand);

                while (reader.Read())
                {
                    User user = ReadUserSqlCommand(reader);
                    users.Add(user);
                }
            }

            return users;
        }


        public void Update(User user)
        {
            using (_connection = new Connection())
            {
                string queryString = @"
                    UPDATE users 
                    SET name = @name,
                        yearsOld = @yearsOld,
                        email = @email,
                        phone = @phone,
                        address = @address
                   WHERE document = @document
                ";

                SqlCommand sqlCommand = new SqlCommand(queryString, _connection.GetConnection());
                sqlCommand.Parameters.AddWithValue("@name", user.GetName().ToString());
                sqlCommand.Parameters.AddWithValue("@yearsOld", user.GetYearsOld().ToString());
                sqlCommand.Parameters.AddWithValue("@email", user.GetEmail().ToString());
                sqlCommand.Parameters.AddWithValue("@phone", user.GetPhone().ToString());
                sqlCommand.Parameters.AddWithValue("@address", user.GetAddress().ToString());
                sqlCommand.Parameters.AddWithValue("@document", user.GetDocumentNumber().ToString());

                _connection.Execute(sqlCommand);
            }
        }

        private User ReadUserSqlCommand(SqlDataReader reader)
        {
            User user = new User(
                new Name(reader.GetString(reader.GetOrdinal("name"))),
                new YearsOld(reader.GetString(reader.GetOrdinal("yearsOld"))),
                new Cpf(reader.GetString(reader.GetOrdinal("document"))),
                new Email(reader.GetString(reader.GetOrdinal("email"))),
                new Phone(reader.GetString(reader.GetOrdinal("phone"))),
                reader.GetString(reader.GetOrdinal("address"))
            );

            return user;
        }
    }
}