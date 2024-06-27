using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string orderID {  get; set; }
        public required string productID {  get; set; }
        public required int quantity { get; set; }   
        public double price { get; set; }
        public string note {  get; set; }

        [ForeignKey(nameof(productID))]
        public virtual Product Products { get; set; }
        [ForeignKey(nameof(orderID))]
        public virtual Order Orders { get; set; }

    }
}
