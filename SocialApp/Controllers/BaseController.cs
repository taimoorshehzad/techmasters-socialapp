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
            var loginUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (System.Web.HttpContext.Current.Request.QueryString["user"] != null && System.Web.HttpContext.Current.Request.QueryString["user"] != "")
            {
                loginUserId = System.Web.HttpContext.Current.Request.QueryString["user"].ToString();
            }

            if (loginUserId != null)
            {
                ProfileViewModel UserData = new ProfileViewModel();
                UserData = _UserManager.GetProfileByUserID(loginUserId);
                ViewBag.LayoutModel = UserData;
            }
        }
    }
}