using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReportDTO
    {
        public int ElectionId { get; set; }

        public string Title { get; set; }

        public int TotalVoters { get; set; }
        public int TotalVoted { get; set; }

        public string TotalVotePercentage { get; set; }

        public List<CandidateVoteDTO> Candidates { get; set; }

        


    }
}
