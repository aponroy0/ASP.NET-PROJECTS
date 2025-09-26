
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Candidate
    {
        public Candidate() { 
         this.Voters = new HashSet<Voter>();
        }
        


        [Key]
        public int CandidateId { get; set; }
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string CandidateName { get; set; }
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Party {  get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Bio {  get; set; }


        [ForeignKey("Election_Id")]
        public int ElectionId { get; set; }
        public virtual Election Election_Id { get; set; }


        public virtual ICollection<Voter> Voters { get; set; }
        
    }
}
