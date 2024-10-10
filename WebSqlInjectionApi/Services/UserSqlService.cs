using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebSqlInjectionApi.Contacts;
using WebSqlInjectionApi.Models;

namespace WebSqlInjectionApi.Services
{
    public class UserSqlService : IUserSqlService
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public UserSqlService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public User GetUserById(int userId)
        {
            User user = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", userId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"]
                        };
                    }
                }
            }

            return user;
        }
    }
}
