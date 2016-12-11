using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialApp.DB.Model;
using System.IO;
using SocialApp.BL;


namespace SocialApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            //ProfileViewModel UserData = new ProfileViewModel();
            //UserData = GetUserBasicInfo();
            //return PartialView("~/Views/Shared/_UserLayout.cshtml", UserData);
            //ViewBag.LayoutModel = UserData;
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="User")]
        public ActionResult UserProfile(string Id)
        {
            OrganizationBL organizationBL = new OrganizationBL();
            var organization = organizationBL.OrganizationList();

            var collection = organization.Select(s => new
            {
                Name = s.Name,
                ID = s.OrganizationID
            }).ToList();
            ViewBag.UserId = Id;
            ViewBag.Organizations = new SelectList(collection, "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult UserProfile(UserProfileViewModel viewModel)
        {
            var userProfileBL = new UserProfileBL();
            userProfileBL.UserProfileInsert(viewModel);
            int? orgID = viewModel.SelectedOrganization;
            return RedirectToAction("Profile" , new { UserId = viewModel.UserID , orgID});
        }
        [Authorize(Roles ="User")]
        public ActionResult Profile(string userID , int? orgID)
        {
            UserProfileBL BL = new UserProfileBL();
            var profile = BL.GetProfileByUserAndOrganization(userID, orgID);
            return View(profile);
        }   
    }
}