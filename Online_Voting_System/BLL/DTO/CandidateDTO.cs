using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CandidateDTO
    {
        public string CandidateName { get; set; }   
        public string Party { get; set; }
        public string Bio {  get; set; }
        public int ElectionId { get; set; }

    }
}
