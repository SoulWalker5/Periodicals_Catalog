using AutoMapper;
using BLL.Interface;
using BLL.ModelBL;
using Microsoft.AspNet.Identity.Owin;
using Periodicals_Catalog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodicals_Catalog_MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _comment;
        private readonly IMapper _mapper;

        public CommentController(ICommentService comment, IMapper mapper)
        {
            _mapper = mapper;
            _comment = comment;
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                var modelBL = _mapper.Map<CommentBL>(model);
                _comment.Create(modelBL);
            }

            var section = Request.UrlReferrer.AbsolutePath.Split('/');

            return RedirectToAction(section[2], section[1], new { id = section[3] });
        }
    }
}
