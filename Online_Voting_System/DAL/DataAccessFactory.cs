using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DataAccessFactory
    {
        public static Irepo<User, int, bool> UserData()
        {
            return new UserRepo();
        }
        public static Irepo<Election, int, bool> ElectionData()
        {
            return new ElectionRepo();
        }
        public static Irepo<Candidate, int, bool> CandidateData()
        {
            return new CandidateRepo();
        }
        public static Irepo<Voter, int, bool> VoterData()
        {
            return new VoterRepo();
        }
        public static IdeleteCandidate<int> DeleteCandidateData()
        {
            return new DeleteCandidateRepo();
        }


    }
}
