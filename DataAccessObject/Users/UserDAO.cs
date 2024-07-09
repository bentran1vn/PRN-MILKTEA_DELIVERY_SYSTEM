using BusinessObject;
using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Users
{
    public class UserDAO
    {
        private readonly MilkTeaDeliveryDBContext _context = new();



        public User LoggedIn(string request, string password)
        {
            try
            {
                var user = this._context.Users.FirstOrDefault(x => (x.userName.Equals(request) && x.password.Equals(password))
                                                            || (x.email.Equals(request) && x.password.Equals(password)));
                if(user == null)
                    return null; 
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public string AddUser(User request)
        {
            try
            {
                if (_context.Users.Any(x => x.userName.Equals(request.userName)))
                    throw new Exception("Duplicated User");
                var user = new User()
                {
                    userName = request.userName,
                    address = request.address ?? null,
                    email = request.email ?? null,
                    create_At = DateTime.UtcNow,
                    create_By = request.create_By,
                    password = request.password,
                    phoneNumber = request.phoneNumber,
                    point = 0,
                    yob = request.yob,
                    rankID = 1,
                };
                if (request.roleID == null)
                {
                    user.roleID = 1;
                }
                else
                {
                    user.roleID = request.roleID;
                }
                this._context.Users.Add(user);
                return this._context.SaveChanges() > 0 ? "Success" : "Fail"; 
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public IEnumerable<User> GetAllUsers() 
        {
            try
            {
                return this._context.Users.ToList();
            }
            catch (Exception ex) 
            { 
                throw new Exception($"{ex.Message}");
            }
        }
        public User GetUsers(string request)
        {
            try
            {
                return this._context.Users.Where(x => x.userName.Equals(request)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public string UpdateUser(User request)
        {
            try
            {
                this._context.Users.Update(request);
                return this._context.SaveChanges() > 0 ? "Success" : "Fail";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public string DeleteUser(string request) 
        {
            try
            {
                var user = this._context.Users.FirstOrDefault(x => x.userName.Equals(request));
                if (user == null)
                    return "Not Found User";
                user.delete_At = DateTime.UtcNow;
                this._context.Users.Update(user);
                return this._context.SaveChanges() > 0 ? "Success":"Fail";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    
    }
}
