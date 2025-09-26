using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class VoterRepo : Irepo<Voter, int, bool>
    {
        VoteContext db;
        public VoterRepo()
        {
            db = new VoteContext();
        }
        public bool Create(Voter obj)
        {
            db.Voteres.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool DeleteCandidateData(int id)
        {
            var exemp = Get(id);
            db.Voteres.Remove(exemp);
            return db.SaveChanges() > 0;
        }

        public List<Voter> Get()
        {
            return db.Voteres.ToList();
        }

        public Voter Get(int id)
        {
            return db.Voteres.Find(id);
        }

        public bool Update(Voter obj)
        {
            var exemp = db.Voteres.Find(obj.ElectionId);
            db.Entry(exemp).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
