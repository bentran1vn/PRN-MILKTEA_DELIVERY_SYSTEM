using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Entities;

namespace Repositories.Users;

public interface IUserRepository
{
    public Task<User> Login(string username, string password);
    
    public IEnumerable<User> GetAll();
}
