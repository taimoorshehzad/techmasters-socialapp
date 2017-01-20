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

            return View(MBL.userMessage(id));
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
                var profile = BL.GetProfileByUserID(userID);
                return View(profile);
            }
            else
            {
                return View("Index");
            }
        }   
 
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

        [HttpPost]
        public ActionResult EditUserProfile(EditUserProfileViewModel viewModel)
        {
            UserProfileBL profileBL = new UserProfileBL();
            profileBL.InsertEditedUserProfile(viewModel);
            int? orgID = viewModel.OrganizationID;
            return RedirectToAction("Profile", new { UserId = viewModel.UserID, orgID });
        }
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

        [HttpPost]
        public JsonResult SearchUsers(string Prefix, int orgID)
        {
            var users = new DisplayProfileBL().GetUsersByOrganization(orgID);
            Prefix = Prefix.ToLower();
            //Searching records from list using LINQ query  
            var searchedUsers = users.Where(w => w.FirstName.ToLower().Contains(Prefix) || w.LastName.ToLower().Contains(Prefix)).Select(s => new
            {
                Route = "/Home/Contact?user=" + s.UserID,
                Name = s.FirstName + " " + s.LastName
            });

            return Json(searchedUsers, JsonRequestBehavior.AllowGet);
        }
    }
}