using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class User
    {
        [Key]
        public string userID { get; set; }
        public string userName {  get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public int roleID {  get; set; }
        public int point {  get; set; }
        public int rankID {  get; set; }
        public DateTime yob { get; set; }
        public string? create_By { get; set; }
        public string? update_By { get; set; }
        public string? delete_By { get; set; }
        public DateTime? create_At { get; set; }
        public DateTime? update_At { get; set; }
        public DateTime? delete_At { get; set; }
        [ForeignKey (nameof(roleID))]
        public virtual Role Roles { get; set; }
        [ForeignKey(nameof(rankID))]
        public virtual Rank Ranks { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
