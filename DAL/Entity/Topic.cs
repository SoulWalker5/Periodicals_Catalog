using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<Periodical> Periodicals { get; set; }
    }
}
