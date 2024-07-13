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

    public void CreateUser(string username, string password, string email, string phonenumber, string address, DateTime dob, int role)
    {
        try
        {
            UserDAO.Instance.Add(username, password, email, phonenumber, address, dob, role);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new Exception(ex.Message);
        }
    }

    public async Task<User?> GetUserById(string id)
    {
        try
        {
            return await UserDAO.Instance.GetUserById(id);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteUserById(string id)
    {
        try
        {
            await UserDAO.Instance.DeleteUserById(id);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateUser(User user)
    {
        try
        {
            await UserDAO.Instance.UpdateUserById(user);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
