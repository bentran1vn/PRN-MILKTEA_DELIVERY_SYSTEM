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
}
