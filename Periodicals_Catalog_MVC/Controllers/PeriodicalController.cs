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

        // POST: Periodical/Create
        [HttpPost]
        public ActionResult Create(PeriodicalModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var articleBL = _mapper.Map<PeriodicalBL>(model);
            _service.Create(articleBL);

            return RedirectToAction("Index");
        }

        // POST: Periodical/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PeriodicalModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var modelBL = _mapper.Map<PeriodicalBL>(model);
            _service.Update(modelBL);

            return RedirectToAction("Index");
        }

        // POST: Periodical/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _service.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
