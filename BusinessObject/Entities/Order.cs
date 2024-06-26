using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class Order
    {
        [Key]
        public string orderID { get; set; }
        public required string userID {  get; set; }
        public string shipperID {  get; set; }
        public string note {  get; set; }
        public string voucherID {  get; set; }
        public double total {  get; set; }
        public string create_By { get; set; }
        public string update_By { get; set; }
        public string delete_By { get; set; }
        public DateTime create_At { get; set; }
        public DateTime update_At { get; set; }
        public DateTime delete_At { get; set; }
        public int status { get; set; }

        [ForeignKey(nameof(voucherID))]
        public virtual Voucher Vouchers { get; set; }
        [ForeignKey(nameof(userID))]
        public virtual User Users { get; set; }
        [ForeignKey(nameof(shipperID))]
        public virtual User Shippers { get; set; }
    }
}
