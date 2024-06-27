using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Voucher
{
    public class VoucherRepository : IVoucherRepository
    {
        public string Add(BusinessObject.Entities.Voucher voucher) => new VoucherDAO().Add(voucher);

        public string Delete(string id) => new VoucherDAO().Delete(id);

        public List<BusinessObject.Entities.Voucher> GetAll() => new VoucherDAO().GetAll();

        public BusinessObject.Entities.Voucher GetVoucher(string id) => new VoucherDAO().GetById(id);

        public List<BusinessObject.Entities.Voucher> Search(string name) => new VoucherDAO().GetByName(name);

        public string Update(BusinessObject.Entities.Voucher voucher) => new VoucherDAO().Update(voucher);
    }
}
