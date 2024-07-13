using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccessObject.Users;

public class UserDAO
{
    private static UserDAO instance = null;
    private static readonly object instanceLock = new();
    private UserDAO() { }
    public static UserDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                instance ??= new UserDAO();
                return instance;
            }
        }
    }

    public async Task<User> Login(string username, string password)
    {
        try
        {
            using (var context = new MilkTeaDeliveryDBContext())
            {
                var account = await context.Users.SingleOrDefaultAsync(a => a.email == username && a.password == password && a.delete_By == null);
                return account;
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public void Add(string username, string password, string email, string phonenumber, string address, DateTime dob, int role)
    {
        try
        {
            using (var context = new MilkTeaDeliveryDBContext())
            {
                var isExist = context.Users.FirstOrDefault(u => u.email.ToLower().Equals(email.ToLower()));
                if (isExist == null)
                {
                    context.Users.Add(new User()
                    {
                        userID = Guid.NewGuid().ToString(),
                        userName = username,
                        password = password,
                        email = email,
                        phoneNumber = phonenumber,
                        address = address,
                        yob = dob,
                        point = 100,
                        roleID = role,
                        rankID = 1,
                        create_At = DateTime.Now
                    });
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Already Exist Account With Same Email");
                }
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public IEnumerable<User> GetAll()
    {
        try
        {
            using (var context = new MilkTeaDeliveryDBContext())
            {
                var account = context.Users.Include(u => u.Roles).Where(x => x.roleID != 2).AsNoTracking().AsEnumerable();
                return account.ToList();
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<User?> GetUserById(string id)
    {
        try
        {
            using (var context = new MilkTeaDeliveryDBContext())
            {
                var account = await context.Users.Include(u => u.Roles).AsNoTracking().FirstOrDefaultAsync(u => u.userID.Equals(id));
                if (account == null)
                {
                    throw new Exception("User Not Exist !");
                }
                return account;
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task DeleteUserById(string id)
    {
        try
        {
            using (var context = new MilkTeaDeliveryDBContext())
            {
                var account = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.userID.Equals(id));
                if (account == null)
                {
                    throw new Exception("User Not Exist !");
                }
                context.Users.Remove(account);
                await context.SaveChangesAsync();
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task UpdateUserById(User user)
    {
        try
        {
            using (var context = new MilkTeaDeliveryDBContext())
            {
                var account = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.userID.Equals(user.userID));
                if (account == null)
                {
                    throw new Exception("User Not Exist !");
                }
                context.Users.Update(user);
                await context.SaveChangesAsync();
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
