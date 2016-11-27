using SocialApp.BL;
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
        private OrganizationBL _organizationBl = new OrganizationBL();

        //DashBoard
        [HttpGet]
        public ActionResult Dashboard()
        {
            DashboardBL DBL = new DashboardBL();
            return View(DBL.DashboardStats());
        }

        //Admin index page
        [HttpGet]
        public ActionResult index()
        {
            OrganizationBL test = new OrganizationBL();
            return View(test.OrganizationList());
        }

        //Create Organization
        [HttpGet]
        public ActionResult CreateOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrganization(AddOrganizationViewModel OrganizationViewModel, HttpPostedFileBase LogoPath)
        {
            String status = _organizationBl.CreateOrganization(OrganizationViewModel, LogoPath);
            ViewBag.StatusMessage = status;
            return View();
        }

        //Edit Organization
        [HttpGet]
        public ActionResult EditOrganization(int? id)
        {
            return View(_organizationBl.GetEditOrganization(id));
        }

        [HttpPost]
        public ActionResult EditOrganization(EditOrganizationViewModel OrganizationViewModel, HttpPostedFileBase LogoPath)
        {
            String status = _organizationBl.EditOrganization(OrganizationViewModel, LogoPath);
            return RedirectToAction("index");
        }

        //Delete Organization
        [HttpGet]
        public ActionResult DeleteOrganization(int? id)
        {
            String status = _organizationBl.DeleteOrganization(id);
            return RedirectToAction("index");
        }
    }
}