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
        public string productID {  get; set; }
        public required string productName { get; set; }
        public required string productDescription { get; set; }
        public required int productType { get; set; } // 1 was hot 0 was cool
        public required double price { get; set; }
        public required int quantity { get; set; }
        public string imgs {  get; set; }
        public string? create_By { get; set; }
        public string? update_By { get; set; }
        public string? delete_By { get; set; }
        public DateTime? create_At { get; set; }
        public DateTime? update_At { get; set; }
        public DateTime? delete_At { get; set; }
        public bool status {  get; set; }
    }
}
