using DataAccessObject.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.User;

public class UserRepository : IUserRepository
{
    public async Task<BusinessObject.Entities.User> Login(string username, string password)
    {
        return await UserDAO.Instance.Login(username, password);
    }
}
