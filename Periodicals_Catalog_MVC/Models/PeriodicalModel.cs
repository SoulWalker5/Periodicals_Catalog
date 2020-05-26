﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodicals_Catalog_MVC.Models
{
    public class PeriodicalModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Period { get; set; } // 1 per mounth

        [Required]
        public string ImageName { get; set; }

        public int NumberOfEdition { get; set; } // Number of periodical 

        [Required]
        public int NumberOfPublications { get; set; } // All number of periodical

        [Required]
        public string Annotation { get; set; }

        public TopicModel Topic { get; set; }
    }
}