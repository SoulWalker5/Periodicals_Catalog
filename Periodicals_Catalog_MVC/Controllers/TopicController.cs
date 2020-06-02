using AutoMapper;
using BLL.Interface;
using BLL.ModelBL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Periodicals_Catalog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodicals_Catalog_MVC.Controllers
{
    public class TopicController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly ITopicService _service;
        private readonly IMapper _mapper;
        
        public TopicController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public TopicController( ITopicService service, IMapper mapper)
        {
            _service = service;
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

        // GET: Topic
        public ActionResult Index()
        {
            var modelBL = _service.GetAll().ToList();
            var modelView = _mapper.Map<IEnumerable<TopicModel>>(modelBL);

            if (!User.IsInRole("Admin"))
            {
                modelView = modelView.Where(p => !p.Name.Contains("XXX"));
            }

            return View(modelView.ToList());
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id, string sortOrder, int? page)
        {
            var modelBL = _service.FindById(id);
            var modelView = _mapper.Map<TopicModel>(modelBL);

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NumberSortParm = sortOrder == "Number" ? "number_desc" : "Number";

            switch (sortOrder)
            {
                case "name_desc":
                    modelView.Periodicals = modelView.Periodicals.OrderByDescending(s => s.Name);
                    break;
                default:
                    modelView.Periodicals = modelView.Periodicals.OrderBy(s => s.Name);
                    break;
            }

            int pageNumber = (page ?? 1);

            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            modelView.PageSetup = currentUser.PageSetup;
            modelView.PageSetup.PageNumber = pageNumber;
            modelView.PageSetup.TotalItems = modelView.Periodicals.Count();

            modelView.Periodicals = modelView.Periodicals.Skip((pageNumber - 1) * modelView.PageSetup.PageSize).Take(modelView.PageSetup.PageSize);

            return View(modelView);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(TopicModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var articleBL = _mapper.Map<TopicBL>(model);
            _service.Create(articleBL);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var modelBL = _service.FindById(id);
            var modelView = _mapper.Map<PeriodicalModel>(modelBL);

            return View(modelView);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(TopicModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var modelBL = _mapper.Map<TopicBL>(model);
            _service.Update(modelBL);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var modelBL = _service.FindById(id);
            var modelView = _mapper.Map<TopicModel>(modelBL);

            return View(modelView);
        }

        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(TopicModel model)
        {
            _service.Remove(model.Id);

            return RedirectToAction("Index");
        }
    }
}
