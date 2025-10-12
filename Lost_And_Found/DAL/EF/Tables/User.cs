using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class User : IAuditableEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Name {  get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string HashPassword { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        [ForeignKey("Role_Id")]
        public string RoleId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public virtual Role Role_Id { get; set; }

        

    }
}
