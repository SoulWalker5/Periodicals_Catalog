using AutoMapper;
using BLL.Interface;
using Newtonsoft.Json;
using Periodicals_Catalog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Periodicals_Catalog_MVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPeriodicalService _periodical;
        private readonly ITopicService _topic;
        private readonly IMapper _mapper;

        public SearchController(ITopicService topic, IMapper mapper, IPeriodicalService periodical)
        {
            _periodical = periodical;
            _topic = topic;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Json()
        {
            var periodiaclBL = _periodical.GetAll().ToList();
            var periodiaclView = _mapper.Map<IEnumerable<PeriodicalModel>>(periodiaclBL);

            var list = JsonConvert.SerializeObject(periodiaclView, Formatting.None,
                 new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                 });

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchString)
        {
            var periodiaclBL = _periodical.GetAll().ToList();
            var periodiaclView = _mapper.Map<IEnumerable<PeriodicalModel>>(periodiaclBL);

            if (!String.IsNullOrEmpty(searchString))
            {
                periodiaclView = periodiaclView.Where(d => d.Name.Equals(searchString, StringComparison.CurrentCultureIgnoreCase)
                                                || d.Topic.Name.Equals(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            return View(periodiaclView);
        }
    }
}