using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Users
{
    public interface IUsersRepository
    {
        User LoggedIn(string request, string password);
        string AddUser(User request);
        IEnumerable<User> GetAllUsers(int pageSize, int pageNUmber);
        User GetUsers(string request);
        string UpdateUser(User request);
        string DeleteUser(string request);

    }
}
