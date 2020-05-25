using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Periodicals_Catalog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodicals_Catalog_MVC.Controllers
{

    public class RoleController : Controller
    {
        private ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();

            return View(Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IdentityRole model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(model.Name))
            {
                roleManager.Create(model);
            }
            //context.Roles.Add(model);

            return RedirectToAction("Index");
        }

        public bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());

                if (s[0].ToString() == "Admin")
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}