using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class MainContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            var addedAuditableEntities = ChangeTracker.Entries<IAuditableEntity>()
                .Where(e => e.State == EntityState.Added)
                .ToList();

            addedAuditableEntities.ForEach(e =>
            {
                e.Entity.CreatedAt = DateTime.UtcNow;
            });

            return base.SaveChanges();
        }
    } 
}
