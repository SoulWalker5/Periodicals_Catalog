using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelBL
{
    public class TopicBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }

        public virtual IEnumerable<PeriodicalBL> Periodicals { get; set; }
    }
}
