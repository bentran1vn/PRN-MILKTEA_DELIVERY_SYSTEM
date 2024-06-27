using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public required int ProductType { get; set; } // 1 for hot, 0 for cool
        public required double Price { get; set; }
        public required int Quantity { get; set; }
        public string Imgs { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public string? DeleteBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public bool Status { get; set; }
    }
}
