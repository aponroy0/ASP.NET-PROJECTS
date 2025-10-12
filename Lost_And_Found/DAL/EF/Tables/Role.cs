using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName ="nvarchar")]
        public string RoleName { get; set; }
    }
}
