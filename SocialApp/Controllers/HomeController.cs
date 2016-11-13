using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocailApp.Repository;
using SocialApp.DB.Model;
using System.IO;

namespace SocialApp.Controllers
{
    public class HomeController : Controller
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

            return View();
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserProfile(UserProfileViewModel viewModel  , HttpPostedFileBase profilePhoto)
        {
            var fileName = Path.GetFileName(profilePhoto.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/User/Profile/Images/"), fileName);
            profilePhoto.SaveAs(path);
            IUserProfileRepository repo = new UserProfileRepository();
            UserProfile user = new UserProfile();
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Address = viewModel.Address;
            user.Gender = viewModel.Gender;
            user.Country = viewModel.Country;
            user.City = viewModel.City;
            user.PhoneNo = viewModel.MobileNO;
            user.DOB = viewModel.DOB;

            repo.Insert(user);
            return View();
        }


    }
}