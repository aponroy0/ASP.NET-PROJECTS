using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ElectionRepo : Irepo<Election, int, bool>
    {
        VoteContext db;
        public ElectionRepo()
        {
            db = new VoteContext();
        }

        public bool Create(Election obj)
        {
            db.Elections.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool DeleteCandidateData(int id)
        {
            var exemp = Get(id);
            db.Elections.Remove(exemp);
            return db.SaveChanges() > 0;
        }

        public List<Election> Get()
        {
            return db.Elections.ToList();
        }

        public Election Get(int id)
        {
            return db.Elections.Find(id);
        }

        public bool Update(Election obj)
        {
            var exemp = db.Elections.Find(obj.ElectionId);
            db.Entry(exemp).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
