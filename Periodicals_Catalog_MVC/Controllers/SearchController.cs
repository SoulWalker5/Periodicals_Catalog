using AutoMapper;
using BLL.Interface;
using Periodicals_Catalog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        // GET: Search
        public ActionResult Index(string searchString)
        {
            //var topicBL = _topic.GetAll().ToList();
            //var topicView = _mapper.Map<IEnumerable<TopicModel>>(topicBL);
            var periodiaclBL = _periodical.GetAll().ToList();
            var periodiaclView = _mapper.Map<IEnumerable<PeriodicalModel>>(periodiaclBL);

            if (!String.IsNullOrEmpty(searchString))
            {
                ////var search = modelView.Where(p => p.Name.Equals(searchString, StringComparison.CurrentCultureIgnoreCase));

                periodiaclView = periodiaclView.Where(d => d.Name.Equals(searchString, StringComparison.CurrentCultureIgnoreCase) || d.Topic.Name.Equals(searchString, StringComparison.CurrentCultureIgnoreCase));

                //topicView = topicView.Where(d => d.Name.Equals(searchString, StringComparison.CurrentCultureIgnoreCase) || d.Periodicals.Where(p => p.Name.Equals(searchString, StringComparison.CurrentCultureIgnoreCase)).Any());
                ////if (!topicView.Any())
                ////{
                ////    periodiaclView = periodiaclView.Where(p => p.Name.Equals(searchString, StringComparison.CurrentCultureIgnoreCase));

                ////    if (!periodiaclView.Any())
                ////    {
                ////        return RedirectToAction("Index", "Topic");
                ////    }
                ////    //@Html.ActionLink("Name", "Details/" + Model.Id, new { sortOrder = ViewBag.NameSortParm })
                ////    return View("~/Views/Periodical/Details.cshtml", "_Layout", periodiaclView);
                ////}
            }

            return View(/*"~/Views/Topic/Index.cshtml", "_Layout", */periodiaclView);
        }
    }
}