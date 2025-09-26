using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Election
    {
        public Election()
        {
            this.Candidates = new List<Candidate>();
        }



        [Key]
        public int ElectionId {  get; set; }
        [Required]
        [StringLength(30)]
        [Column(TypeName ="varchar")]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }

        [ForeignKey("User_Id")]
        public int CreatedBy { get; set; }

        public virtual User User_Id { get; set; }


        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
