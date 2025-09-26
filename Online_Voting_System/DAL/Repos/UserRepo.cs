using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Irepo<User, int, bool>
    {
        VoteContext db;
        public UserRepo() { 
          db = new VoteContext();
        }
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool DeleteCandidateData(int id)
        {
            var exemp = Get(id);
            db.Users.Remove(exemp);
            return db.SaveChanges()>0;  
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var exemp = db.Users.Find(obj.UserId);
            db.Entry(exemp).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;    
        }
    }
}
