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

            var pageSetup = DefinePageSetup(modelView, pageNumber);
            ViewData["PageSetup"] = pageSetup;

            modelView.Periodicals = modelView.Periodicals.Skip((pageNumber - 1) * pageSetup.PageSize).Take(pageSetup.PageSize);

            return View(modelView);
        }
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
                return View();

            else
                return RedirectToAction("Login", "Account");
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(TopicModel model)
        {
            if (model.UploadImage != null)
            {
                string filePath = System.IO.Path.GetFileName(model.UploadImage.FileName);

                model.UploadImage.SaveAs(Server.MapPath("~/Images/Topics/" + filePath));
                model.ImageName = filePath;
            }

            else
            {
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var modelBL = _mapper.Map<TopicBL>(model);
            _service.Create(modelBL);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var modelBL = _service.FindById(id);
            var modelView = _mapper.Map<TopicModel>(modelBL);

            return View(modelView);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(TopicModel model)
        {
            if (model.UploadImage != null && ModelState.IsValid)
            {
                string filePath = System.IO.Path.GetFileName(model.UploadImage.FileName);

                model.UploadImage.SaveAs(Server.MapPath("~/Images/Topics/" + filePath));
                model.ImageName = filePath;
            }

            else
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


        public ActionResult Partial()
        {


            return PartialView("_Pagination");
        }

        /// <summary>
        /// Methode which define number of elements that are displayed on the page.
        /// </summary>
        /// <param name="modelView"> Current model</param>
        /// <param name="pageNumber"> Current number of page</param>
        private PageSetup DefinePageSetup(TopicModel modelView, int pageNumber)
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
                    TotalItems = modelView.Periodicals.Count()
                };

                return pageSetup;
            }
        }
    }
}
