using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Periodicals_Catalog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Periodicals_Catalog_MVC.Controllers
{

    public class RoleController : Controller
    {
        private readonly ApplicationDbContext context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public RoleController()
        {
            context = new ApplicationDbContext();
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }
        public RoleController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: Role/Index
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var roles = context.Roles.ToList();

            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IdentityRole model)
        {
            if(!_roleManager.RoleExists(model.Name))
            {
                _roleManager.Create(model);
            }

            return RedirectToAction("Index");
        }
    }
}