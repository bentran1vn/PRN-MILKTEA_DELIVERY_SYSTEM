using BusinessObject.Entities;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Roles
{
    public class RoleDAO
    {
        private readonly MilkTeaDeliveryDBContext _context;
        public RoleDAO(MilkTeaDeliveryDBContext context)
        {
            this._context = context;
        }
        public string AddRole(Role request)
        {
            try
            {
                if (request == null)
                    return "fail";
                if ((this._context.Roles.Where(x => x.roleName.Equals(request.roleName) && x.delete_At == null).FirstOrDefault()) != null)
                    return "Duplicate role";
                this._context.Roles.Add(request);
                this._context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public string RemoveRole(int request)
        {
            try
            {
                var role = this._context.Roles.Where(x => x.roleID.Equals(request) && x.delete_At == null).FirstOrDefault();
                if (role == null)
                    return "not found";
                role.delete_At = DateTime.UtcNow;
                this._context.Roles.Update(role);
                this._context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public Role GetRole(int request)
        {
            try
            {
                return this._context.Roles.Where(x => x.roleID.Equals(request) && x.delete_At == null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public List<Role> GetAllRanks()
        {
            try
            {
                return this._context.Roles.Where(x => x.delete_At == null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public string UpdateRank(Role request)
        {
            try
            {
                if (request == null)
                    return "fail";
                var role = this._context.Roles.Where(x => x.roleID.Equals(request) && x.delete_At == null).FirstOrDefault();
                if (role == null)
                    return "Not found";
                this._context.Roles.Update(request);
                this._context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
