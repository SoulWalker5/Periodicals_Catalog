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
            var modelView = _mapper.Map<IEnumerable<PeriodicalModel>>(periodiaclBL);
            
            modelView = modelView.Where(d => d.Name.ToLower().Contains(searchString.ToLower()));

            int pageNumber = (page ?? 1);

            var pageSetup = DefinePageSetup(modelView, pageNumber);
            ViewData["PageSetup"] = pageSetup;
            ViewData["SearchString"] = searchString;

            modelView = modelView.Skip((pageNumber - 1) * pageSetup.PageSize).Take(pageSetup.PageSize);

            return View(modelView);
        }

        /// <summary>
        /// Methode which define number of elements that are displayed on the page.
        /// </summary>
        /// <param name="modelView"> Current model</param>
        /// <param name="pageNumber"> Current number of page</param>
        private PageSetup DefinePageSetup(IEnumerable<PeriodicalModel> modelView, int pageNumber)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = UserManager.FindById(User.Identity.GetUserId());

                return currentUser.PageSetup;
            }

            else
            {
                var pageSetup = new PageSetup
                {
                    PageNumber = pageNumber,
                    TotalItems = modelView.Count()
                };

                return pageSetup;
            }
        }
    }
}