using AutoMapper;
using BLL.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        private ApplicationUserManager _userManager;
        private readonly IPeriodicalService _periodical;
        private readonly ITopicService _topic;
        private readonly IMapper _mapper;

        public SearchController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public SearchController(ITopicService topic, IMapper mapper, IPeriodicalService periodical)
        {
            _periodical = periodical;
            _topic = topic;
            _mapper = mapper;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public ActionResult Json()
        {
            var periodiaclBL = _periodical.GetAll().ToList();
            var periodiaclView = _mapper.Map<IEnumerable<PeriodicalModel>>(periodiaclBL);

            var filteredData = periodiaclView.Select(c => new { c.Name, c.ImageName });

            var listOfData = JsonConvert.SerializeObject(filteredData, Formatting.None,
                 new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                 });

            return Json(listOfData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchString, int? page)
        {
            var periodiaclBL = _periodical.GetAll().ToList();
            var periodicalView = _mapper.Map<IEnumerable<PeriodicalModel>>(periodiaclBL);

            if (!String.IsNullOrEmpty(searchString))
            {
                periodicalView.Where(d => d.Name.ToLower().Contains(searchString) || d.Topic.Name.ToLower().Contains(searchString));

                int pageNumber = (page ?? 1);

                DefinePageSetup(periodicalView, pageNumber);

            }

            return View(periodicalView);
        }

        /// <summary>
        /// Methode which define number of elements that are displayed on the page.
        /// </summary>
        /// <param name="modelView"> Current model</param>
        /// <param name="pageNumber"> Current number of page</param>
        private void DefinePageSetup(IEnumerable<PeriodicalModel> modelView, int pageNumber)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = UserManager.FindById(User.Identity.GetUserId());

                modelView.Select(x => x.PageSetup = currentUser.PageSetup);
                modelView.Select(x => x.PageSetup.PageNumber = pageNumber);
                modelView.Select(x => x.PageSetup.TotalItems = modelView.Count());
            }

            else
            {
                modelView.Select(x => x.PageSetup = new PageSetup
                {
                    PageNumber = pageNumber,
                    TotalItems = modelView.Count()
                });
            }
        }
    }
}