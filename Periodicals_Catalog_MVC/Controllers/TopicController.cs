﻿using AutoMapper;
using BLL.Interface;
using BLL.ModelBL;
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
        private readonly ITopicService _service;
        private readonly IMapper _mapper;
        public TopicController(ITopicService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Topic
        public ActionResult Index()
        {
            var modelBL = _service.GetAll().ToList();
            var modelView = _mapper.Map<IEnumerable<TopicModel>>(modelBL);

            return View(modelView);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            var modelBL = _service.FindById(id);
            var modelView = _mapper.Map<TopicModel>(modelBL);

            return View(modelView);
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

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TopicModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var modelBL = _mapper.Map<TopicBL>(model);
            _service.Update(modelBL);

            return RedirectToAction("Index");
        }

        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _service.Remove(id);

            return RedirectToAction("Index");
        }
    }
}