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

    public void CreateUser(string username, string password, string email, string phonenumber, string address, DateTime dob, int role);

    public Task<User?> GetUserById(string id);

    public Task DeleteUserById(string id);

    public Task UpdateUser(User user);
}
