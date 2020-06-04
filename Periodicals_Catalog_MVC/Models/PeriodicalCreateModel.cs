using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodicals_Catalog_MVC.Models
{
    public class PeriodicalCreateModel : PeriodicalModel
    {
        [Required]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}