using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.User;

public interface IUserRepository
{
    public Task<BusinessObject.Entities.User> Login(string username, string password);
}
