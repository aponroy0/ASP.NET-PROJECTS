using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DeleteCandidateRepo : IdeleteCandidate<int>
    {

        VoteContext db;
        public DeleteCandidateRepo()
        {
            db = new VoteContext();
        }
        public bool DeleteCandidate(int id_e, int id_c)
        {
            var election = db.Elections.Find(id_e);

            if (election == null) 
            {
                return false;
            }
            else
            {
                var candidate = (from u in election.Candidates.ToList() where u.CandidateId == id_c select u).FirstOrDefault();
                db.Candidates.Remove(candidate);
                db.SaveChanges();

                // Here we are using FirstORDefault for a single return value.
                // If we dont use that, it will return a list of candidates.

                if (candidate != null)
                {
                    return true;
                }

                return false;

            }

        }
    }
}
