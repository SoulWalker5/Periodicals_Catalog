using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodicals_Catalog_MVC.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        [Required]
        //[DisplayFormat(DataFormatString = "{dddd, dd MMMM yyyy HH:mm}")]
        public DateTime CreateTime { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public int PeriodicalId { get; set; }

        public PeriodicalModel Periodical { get; set; }
    }
}