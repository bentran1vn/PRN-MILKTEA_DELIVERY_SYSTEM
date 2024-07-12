using DataAccessObject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Entities;

namespace Repositories.Users;

public class UserRepository : IUserRepository
{
    public async Task<BusinessObject.Entities.User> Login(string username, string password)
    {
        return await UserDAO.Instance.Login(username, password);
    }

    public IEnumerable<User> GetAll()
    {
        return UserDAO.Instance.GetAll();
    }
}
