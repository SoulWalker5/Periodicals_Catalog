using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodicals_Catalog_MVC.Models
{
    public class TopicModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageName { get; set; }

        public IEnumerable<PeriodicalModel> Periodicals { get; set; }
    }
}