using BusinessObject;
using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class VoucherDAO
    {
        public List<Voucher> GetAll()
        {
            try
            {
                var db = new MilkTeaDeliveryDBContext();
                return db.Vouchers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Voucher> GetByName(string name)
        {
            try
            {
                var db = new MilkTeaDeliveryDBContext();
                return db.Vouchers.Where(x => x.voucherName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Voucher GetById(string id)
        {
            try
            {
                var db = new MilkTeaDeliveryDBContext();
                var result = db.Vouchers.FirstOrDefault(x => x.voucherID.Equals(id));
                return result == null ? throw new Exception("Not found voucher!") : result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Add(Voucher voucher)
        {
            try
            {
                var db = new MilkTeaDeliveryDBContext();
                if (db.Vouchers.Any(x => x.voucherID.Equals(voucher.voucherID)))
                    throw new Exception("Duplicated id");
                voucher.create_At = DateTime.Now;
                await db.Vouchers.AddAsync(voucher);
                return await db.SaveChangesAsync() > 0 ? "Add success!" : "Add failed!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Delete(string id)
        {
            try
            {
                var db = new MilkTeaDeliveryDBContext();
                var found = db.Vouchers.FirstOrDefault(x => x.voucherID.Equals(id)) ?? throw new Exception("Not found voucher!");
                found.status = false;
                found.delete_At = DateTime.Now;
                return db.SaveChanges() > 0 ? "Delete success!" : "Delete failed!";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Update(Voucher voucher)
        {
            try
            {
                var db = new MilkTeaDeliveryDBContext();
                var found = db.Vouchers.FirstOrDefault(x => x.voucherID.Equals(voucher.voucherID)) ?? throw new Exception("Not found voucher!");
                found.voucherName = voucher.voucherName;
                found.description = voucher.description;
                found.amount = voucher.amount;
                found.min = voucher.min;
                found.quantity = voucher.quantity;
                found.create_By = voucher.create_By;
                found.create_At = voucher.create_At;
                found.update_By = voucher.update_By;
                found.update_At = voucher.update_At;
                found.status = voucher.status;

                return db.SaveChanges() > 0 ? "Update success!" : "Update failed!";

            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message); 
            }
        }
    }
}
