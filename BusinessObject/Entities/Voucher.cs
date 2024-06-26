using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class Voucher
    {
        [Key]
        public string voucherID {  get; set; }
        public required string voucherName { get; set; }
        public required string description { get; set; }
        public required double amount {  get; set; }
        public required double min { get; set; }
        public required double max { get; set; }
        public required int quantity { get; set; }
        public string? create_By { get; set; }
        public string? update_By { get; set; }
        public string? delete_By { get; set; }
        public DateTime? create_At { get; set; }
        public DateTime? update_At { get; set; }
        public DateTime? delete_At { get; set; }
        public bool status {  get; set; }
    }
}
