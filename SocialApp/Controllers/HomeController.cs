using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialApp.DB.Model;
using System.IO;
using SocialApp.BL;
using Microsoft.AspNet.Identity;

namespace SocialApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            UserProfileBL profileBL = new UserProfileBL();
            var userID = User.Identity.GetUserId();
            if (userID!= null)
            {
                var check = profileBL.IsProfilecompleted(userID);
                if (check == false || check == null)
                {
                    return RedirectToAction("UserProfile", "Home", new { id = userID });
                }
            }
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

        [Authorize(Roles = "User")]
        public ActionResult Conversation()
        {
            var user = User.Identity.GetUserId();
            var MBL = new MessageBL();
            return View(MBL.Conversation(user));
        }
        [Authorize(Roles = "User")]
        public ActionResult Message(int? id)
        {
            var MBL = new MessageBL();

            return PartialView(MBL.userMessage(id));
        }

        [HttpGet]
        [Authorize(Roles ="User")]
        public ActionResult UserProfile(string Id)
        {
            if (Id != null)
            {
                OrganizationBL organizationBL = new OrganizationBL();
                var organization = organizationBL.OrganizationList();

                var collection = organization.Select(s => new
                {
                    Name = s.Name,
                    ID = s.OrganizationID
                }).ToList();

                UserProfileBL userProfile = new UserProfileBL();
                var countries = userProfile.GetCountries().Select(s => new
                {
                    Text = s.CoutnryName,
                    Value = s.CountryID
                }).ToList();

                ViewBag.UserId = Id;
                ViewBag.Organizations = new SelectList(collection, "ID", "Name");
                ViewBag.CountryDropDown = new SelectList(countries, "Value", "Text");
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        [Authorize(Roles = "User")]
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
            if (userID != null && orgID !=null)
            {
                UserProfileBL BL = new UserProfileBL();
                var profile = BL.GetProfileByUserIdentity(userID);
                return View(profile);
            }
            else
            {
                return View("Index");
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult EditUserProfile(string userID, int? orgID)
        {
            if (userID != null && orgID != null)
            {
                UserProfileBL profileBL = new UserProfileBL();

                var countries = profileBL.GetCountries().Select(s => new
                {
                    Text = s.CoutnryName,
                    Value = s.CountryID
                }).ToList();
                ViewBag.CountryDropDown = new SelectList(countries, "Value", "Text");

                EditUserProfileViewModel viewModel = profileBL.EditUserProfile(userID, orgID);
                return View(viewModel);
            }
            else
            {
                return View("Index");
            }
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult EditUserProfile(EditUserProfileViewModel viewModel)
        {
            UserProfileBL profileBL = new UserProfileBL();
            profileBL.InsertEditedUserProfile(viewModel);
            int? orgID = viewModel.OrganizationID;
            return RedirectToAction("Profile", new { UserId = viewModel.UserID, orgID });
        }

        [Authorize(Roles = "User")]
        public JsonResult StatesByCountryID(int id)
        {
            UserProfileBL bl = new UserProfileBL();
            List<SelectListItem> list = new List<SelectListItem>();
            var states = bl.GetStatesByCountryId(id).Select(s => new
            {
                Text = s.StateName,
                Id = s.StateID
            }).ToList();
            var state = new SelectList(states, "Id", "Text");
            return Json(new { state }, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "User")]
        public JsonResult CitesByStateID(int id)
        {
            UserProfileBL bl = new UserProfileBL();
            List<SelectListItem> list = new List<SelectListItem>();
            var cities = bl.GetCitiesByStateId(id).Select(s => new
            {
                Text = s.CityName,
                Id = s.CityID
            }).ToList();
            var city = new SelectList(cities, "Id", "Text");
            return Json(new { city }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        public ActionResult Wall()
        {
            var userID = User.Identity.GetUserId();
            if (Request.QueryString["user"] != null && Request.QueryString["user"] != "")
            {
                userID = Request.QueryString["user"].ToString();
            }
            else
            {
                userID = new UserProfileBL().GetProfileByUserIdentity(userID).UserProfileID.ToString();
            }

            var postVM = new PostBL().GetPostsWithLikesAndComments(Convert.ToInt32(userID));
            return View(postVM);
        }

        [Authorize(Roles = "User")]
        public ActionResult PostComments(int postID)
        {
            var postComments = new CommentBL().GetCommentsByPostID(postID);
            return PartialView(postComments);
        }
    }
}