using WebSqlInjectionApi.Models;

namespace WebSqlInjectionApi.Contacts
{
    public interface IUserSqlService
    {
        User GetUserById(int userId);
    }
}