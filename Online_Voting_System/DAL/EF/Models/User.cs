using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class User
    {
        public User() { 
        this.Elections = new List<Election>();
        }


        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string FullName { get; set; }
        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        public virtual ICollection<Election> Elections { get; set; }
    }
}
