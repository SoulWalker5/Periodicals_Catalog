using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelBL
{
    public class PeriodicalBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Period { get; set; } // 1 per mounth
        public string ImageName { get; set; }
        public int NumberOfEdition { get; set; } // Number of periodical 
        public int NumberOfPublications { get; set; } // All number of periodical
        public string Annotation { get; set; }
        public int TopicId { get; set; }

        public virtual TopicBL Topic { get; set; }
    }
}
