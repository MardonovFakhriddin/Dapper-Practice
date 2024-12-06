namespace Infrustructure.Service;
using Infrustructure.Models;

public interface IUserService
{
    bool DeleteUser(int id);
    bool UpdateUser(User user);
    bool InsertUser(User user);
    List<User> GetUsers();
    User GetUserById(int id);
}