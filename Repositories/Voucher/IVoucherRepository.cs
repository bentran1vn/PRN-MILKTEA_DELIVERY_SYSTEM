using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Voucher
{
    public interface IVoucherRepository
    {
        List<BusinessObject.Entities.Voucher> GetAll();
        List<BusinessObject.Entities.Voucher> Search(string name);
        BusinessObject.Entities.Voucher GetVoucher(string id);
        string Add(BusinessObject.Entities.Voucher voucher);
        string Delete(string id);
        string Update(BusinessObject.Entities.Voucher voucher);
    }
}
