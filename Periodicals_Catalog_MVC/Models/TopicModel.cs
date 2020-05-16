using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodicals_Catalog_MVC.Models
{
    public class TopicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }

        public virtual IEnumerable<PeriodicalModel> Periodicals { get; set; }
    }
}