using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interface;
using BLL.ModelBL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Periodicals_Catalog_MVC.Models;

namespace Periodicals_Catalog_MVC.Controllers
{
    public class PeriodicalController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly IPeriodicalService _periodical;
        private readonly ITopicService _topic;
        private readonly IMapper _mapper;

        public PeriodicalController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public PeriodicalController(IPeriodicalService periodical, IMapper mapper, ITopicService topic)
        {
            _topic = topic;
            _periodical = periodical;
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

        // GET: Periodical
        public ActionResult Index(string sortOrder)
        {
            var modelBL = _periodical.GetAll().ToList();
            var modelView = _mapper.Map<IEnumerable<PeriodicalModel>>(modelBL);

            if (!User.IsInRole("Admin"))
            {
                var hz = _topic.GetAll().Where(x => x.Name.Contains("XXX")).FirstOrDefault();
                modelView = modelView.Where(p => p.TopicId != hz.Id);
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            switch (sortOrder)
            {
                case "name_desc":
                    modelView = modelView.OrderByDescending(s => s.Name);
                    break;
                case "Number":
                    modelView = modelView.OrderBy(s => s.NumberOfPublications);
                    break;
                case "number_desc":
                    modelView = modelView.OrderByDescending(s => s.NumberOfPublications);
                    break;
                default:
                    modelView = modelView.OrderBy(s => s.Name);
                    break;
            }

            return View(modelView);
        }

        // GET: Periodical/Details/5
        public ActionResult Details(int id)
        {
            var modelBL = _periodical.FindById(id);
            var modelView = _mapper.Map<PeriodicalModel>(modelBL);
            modelView.Comments =modelView.Comments.OrderByDescending(x => x.CreateTime);

            return View(modelView);
        }
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                DataForDropDown();

                return View();
            }

            else
                return RedirectToAction("Login", "Account");
        }

        // POST: Periodical/Create
        [HttpPost]
        public ActionResult Create(PeriodicalModel model)
        {
            if (model.UploadImage != null && ModelState.IsValid)
            {
                string filePath = System.IO.Path.GetFileName(model.UploadImage.FileName);

                model.UploadImage.SaveAs(Server.MapPath("~/Images/" + filePath));
                model.ImageName = filePath;
            }

            else
            {
                DataForDropDown();

                return View(model);
            }

            var modelBL = _mapper.Map<PeriodicalBL>(model);
            _periodical.Create(modelBL);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var modelBL = _periodical.FindById(id);
            var modelView = _mapper.Map<PeriodicalModel>(modelBL);

            DataForDropDown();

            return View(modelView);
        }

        // POST: Periodical/Edit/5
        [HttpPost]
        public ActionResult Edit(PeriodicalModel model)
        {
            if (model.UploadImage != null)
            {
                string filePath = System.IO.Path.GetFileName(model.UploadImage.FileName);

                model.UploadImage.SaveAs(Server.MapPath("~/Images/" + filePath));
                model.ImageName = filePath;
            }

            if (!ModelState.IsValid)
            {
                DataForDropDown();

                return View(model);
            }

            var modelBL = _mapper.Map<PeriodicalBL>(model);
            _periodical.Update(modelBL);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var modelBL = _periodical.FindById(id);
            var modelView = _mapper.Map<PeriodicalModel>(modelBL);

            return View(modelView);
        }

        // POST: Periodical/Delete/5
        [HttpPost]
        public ActionResult Delete(PeriodicalModel model)
        {
            _periodical.Remove(model.Id);

            return RedirectToAction("Index");
        }

        public void DataForDropDown()
        {
            ViewData["Period"] = new SelectList(_periodical.GetAll().Select(x => x.Period).Distinct(), "Period");
            ViewData["Topic"] = new SelectList(_topic.GetAll(), "Id", "Name");
        }
    }
}
