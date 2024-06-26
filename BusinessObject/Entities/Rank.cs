using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class Rank
    {
        [Key]
        public int rankID { get; set; }
        public required string rankName { get; set; }
        public required string description { get; set; }
        public string? create_By { get; set; }
        public string? update_By { get; set; }
        public string? delete_By { get; set; }
        public DateTime? create_At { get; set; }
        public DateTime? update_At { get; set; }
        public DateTime? delete_At { get; set; }

    }
}
