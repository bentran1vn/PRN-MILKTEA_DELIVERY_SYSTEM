using BusinessObject;
using Microsoft.EntityFrameworkCore;


namespace DataAccessObject.User;

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

    public async Task<BusinessObject.Entities.User> Login(string username, string password)
    {
        using var context = new MilkTeaDeliveryDBContext();
        try
        {
            var account = await context.Users.SingleOrDefaultAsync(a => a.email == username && a.password == password && a.delete_By == null);
            return account;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
