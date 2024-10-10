using Dapper;
using Microsoft.Data.SqlClient;
using WebSqlInjectionApi.Contacts;
using WebSqlInjectionApi.Data;
using WebSqlInjectionApi.Models;

namespace WebSqlInjectionApi.Services
{
    public class UserDapperService : IUserDapperService
    {
        private readonly DapperContext _context;

        public UserDapperService(DapperContext context)
        {
            _context = context;
        }

        public User GetUserById(int userId)
        {
            var users = new User();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                users = connection.QueryFirstOrDefault<User>("SELECT Id, Name, Email FROM Users Where Id=@Id", new { Id = userId });

            }

            return users;
        }
    }
}
