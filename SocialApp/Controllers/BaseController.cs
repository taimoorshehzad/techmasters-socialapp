using Microsoft.AspNet.Identity;
using SocialApp.BL;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialApp.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base

        UserProfileBL _UserManager = new UserProfileBL();

        public BaseController()
        {
            //var LoginUserId = User.Identity.GetUserId();
            //var loginUserId = HttpContext.User.Identity.GetUserId();

            var loginUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ProfileViewModel UserData = new ProfileViewModel();
            UserData = _UserManager.GetProfileByUserId(loginUserId);
            ViewBag.LayoutModel = UserData;

        }
    }
}