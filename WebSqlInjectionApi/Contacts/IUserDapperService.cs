using WebSqlInjectionApi.Models;

namespace WebSqlInjectionApi.Contacts
{
    public interface IUserDapperService
    {
        User GetUserById(int userId);
    }
}