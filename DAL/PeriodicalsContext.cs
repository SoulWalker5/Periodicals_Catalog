using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PeriodicalsContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Periodical> Periodicals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Topic>()
                .HasMany(x => x.Periodicals)
                .WithRequired(x => x.Topic)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Periodical>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Periodical)
                .WillCascadeOnDelete(false);
        }
    }
    


}
