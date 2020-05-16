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
    }


}
