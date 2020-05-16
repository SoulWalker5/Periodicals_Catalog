﻿using AutoMapper;
using BLL.Interface;
using BLL.Service;
using Periodicals_Catalog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodicals_Catalog_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicService _topic;
        private readonly IPeriodicalService _periodical;
        private readonly IMapper _mapper;
        public HomeController()
        {
        }
        public HomeController(ITopicService service, IPeriodicalService periodical, IMapper mapper)
        {
            _topic = service;
            _mapper = mapper;
            _periodical = periodical;
        }
        public RedirectResult Index()
        {
            //var topic = _topic.GetAll().ToList();
            //var topicView = _mapper.Map<IEnumerable<TopicModel>>(topic);

            //return View(topicView);

            return RedirectPermanent("/Topic/Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderBar()
        {
            var topic = _topic.GetAll().ToList();
            var topicView = _mapper.Map<IEnumerable<TopicModel>>(topic);

            return PartialView("RenderBar", topicView);
        }
    }
}