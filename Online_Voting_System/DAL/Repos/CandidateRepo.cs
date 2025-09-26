using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CandidateRepo : Irepo<Candidate, int, bool>
    {
        VoteContext db;
        public CandidateRepo()
        {
            db = new VoteContext();
        }
        public bool Create(Candidate obj)
        {
            db.Candidates.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool DeleteCandidateData(int id)
        {
            var exemp = Get(id);
            db.Candidates.Remove(exemp);
            return db.SaveChanges() > 0;
        }

        public List<Candidate> Get()
        {
            return db.Candidates.ToList();
        }

        public Candidate Get(int id)
        {
            return db.Candidates.Find(id);
        }

        public bool Update(Candidate obj)
        {
            var exemp = db.Candidates.Find(obj.ElectionId);
            db.Entry(exemp).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
