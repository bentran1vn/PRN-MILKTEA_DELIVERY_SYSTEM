using BusinessObject.Entities;
using DataAccessObject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Users
{
    public class UserRepository : IUsersRepository
    {
        private readonly UserDAO user = new UserDAO();
        public string AddUser(User request)
        {
            return user.AddUser(request);
        }

        public string DeleteUser(string request)
        {
            return user.DeleteUser(request);
        }

        public IEnumerable<User> GetAllUsers(int pageSize, int pageNumber)
        {
            var result = user.GetAllUsers();
            return result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public User GetUsers(string request)
        {
            return user.GetUsers(request);
        }

        public User LoggedIn(string request, string password)
        {
            return user.LoggedIn(request, password);
        }

        public string UpdateUser(User request)
        {
            return user.UpdateUser(request);
        }
    }
}
