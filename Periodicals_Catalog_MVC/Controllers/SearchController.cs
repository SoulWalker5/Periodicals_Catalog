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
        private readonly ITopicService _service;
        private readonly IMapper _mapper;

        public SearchController(ITopicService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: Search
        public ActionResult Index(string searchString)
        {
            var modelBL = _service.GetAll().ToList();
            var modelView = _mapper.Map<IEnumerable<TopicModel>>(modelBL);

            if (!String.IsNullOrEmpty(searchString))
            {
                modelView = modelView.Where(d => d.Periodicals.Where(p => p.Name.Contains(searchString)
                                                    || p.Name.Contains(searchString.ToUpper())).Any());
            }

            return View(modelView);
        }
    }
}