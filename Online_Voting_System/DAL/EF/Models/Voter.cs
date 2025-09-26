using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
   public class Voter
    {
        [Key] 
        public int VoterId { get; set; }
        [ForeignKey("User_Id")]
        public int UserId { get; set; }
      
  
        [ForeignKey("Candidate_Id")]
        public int CandidateId { get; set; }
        [ForeignKey("Election_Id")]
        public int ElectionId { get; set; }




        public virtual User User_Id { get; set; }
        public virtual Candidate Candidate_Id { get; set; }
        public virtual Election Election_Id { get; set; }


    }
}
