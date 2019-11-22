using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Models.User
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public int Height{ get; set; }
        public int Weight { get; set; }
        public User User { get; set; }
    }
}
