using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interface;
using BLL.ModelBL;
using Periodicals_Catalog_MVC.Models;

namespace Periodicals_Catalog_MVC.Controllers
{
    public class PeriodicalController : Controller
    {
        private readonly IPeriodicalService _service;
        private readonly IMapper _mapper;
        public PeriodicalController(IPeriodicalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Periodical
        public ActionResult Index(string sortOrder)
        {
            var modelBL = _service.GetAll().ToList();
            var modelView = _mapper.Map<IEnumerable<PeriodicalModel>>(modelBL);

            if (!User.IsInRole("Admin"))
            {
                modelView = modelView.Where(p => !p.Topic.Name.Contains("XXX"));
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NumberSortParm = sortOrder == "Number" ? "number_desc" : "Number";

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
            var modelBL = _service.FindById(id);
            var modelView = _mapper.Map<PeriodicalModel>(modelBL);

            return View(modelView);
        }
        public ActionResult Create()
        {
            DataForDropDown();

            return View();
        }

        // POST: Periodical/Create
        [HttpPost]
        public ActionResult Create(PeriodicalModel model)
        {
            if (!ModelState.IsValid)
            {
                DataForDropDown();

                return View(model);
            }

            var articleBL = _mapper.Map<PeriodicalBL>(model);
            _service.Create(articleBL);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var modelBL = _service.FindById(id);
            var modelView = _mapper.Map<PeriodicalModel>(modelBL);

            DataForDropDown();

            return View(modelView);
        }

        // POST: Periodical/Edit/5
        [HttpPost]
        public ActionResult Edit(PeriodicalModel model)
        {
            if (!ModelState.IsValid)
            {
                DataForDropDown();

                return View(model);
            }

            var modelBL = _mapper.Map<PeriodicalBL>(model);
            _service.Update(modelBL);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var modelBL = _service.FindById(id);
            var modelView = _mapper.Map<PeriodicalModel>(modelBL);

            DataForDropDown();

            return View(modelView);
        }

        // POST: Periodical/Delete/5
        [HttpPost]
        public ActionResult Delete(PeriodicalModel model)
        {
            _service.Remove(model.Id);

            return RedirectToAction("Index");
        }

        public void DataForDropDown()
        {
            ViewBag.Period = new SelectList(_service.GetAll().Select(x => x.Period).Distinct(), "Period");
            ViewBag.Topic = new SelectList(_service.GetAll().Select(x => x.Topic).Select(c => c.Name), "Topic");
        } 
    }
}
