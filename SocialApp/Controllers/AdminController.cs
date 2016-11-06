using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Organization()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrganization(AddOrganizationViewModel viewModel)
        {
            return RedirectToAction("Organization");
        }
    }
}