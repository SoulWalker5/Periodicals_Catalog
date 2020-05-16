using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodicals_Catalog_MVC.Models
{
    public class PeriodicalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Period { get; set; } // 1 per mounth
        public string ImageName { get; set; }
        public int NumberOfEdition { get; set; } // Number of periodical 
        public int NumberOfPublications { get; set; } // All number of periodical
        public string Annotation { get; set; }

        public virtual TopicModel Topic { get; set; }
    }
}