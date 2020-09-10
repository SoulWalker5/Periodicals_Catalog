using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelBL
{
    public class CommentBL
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }

        public int PeriodicalId { get; set; }

        public virtual PeriodicalBL Periodical { get; set; }

    }
}