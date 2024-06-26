using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class FeedBack
    {
        [Key]
        public int feedBackID { get; set; }
        public string content { get; set; }
        public required string userID { get; set; }
        public int point { get; set; }
        public string productID { get; set; }
        public string? create_By { get; set; }
        public string? update_By { get; set; }
        public string? delete_By { get; set; }
        public DateTime? create_At { get; set; }
        public DateTime? update_At { get; set; }
        public DateTime? delete_At { get; set; }
        public required bool status {  get; set; }
        [ForeignKey(nameof(productID))]
        public virtual OrderDetail Products { get; set; }
    }
}
