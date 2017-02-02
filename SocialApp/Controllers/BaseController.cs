using SocialApp.BL;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialApp.Utility;

namespace SocialApp.Controllers
{
    public class BaseController : Controller
    {
        
        public BaseController()
        {
            var userProfileID = System.Web.HttpContext.Current.User.Identity.GetUserProfileID();
            int userProfileIDCopy = userProfileID;
            if (System.Web.HttpContext.Current.Request.QueryString["user"] != null && System.Web.HttpContext.Current.Request.QueryString["user"] != "")
            {
                userProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["user"]);
            }
           
            if (userProfileID > 0)
            {
                var userProfileBL = new UserProfileBL();
                var friendRequestBL = new FriendRequestBL();
                var notificationBL = new NotificationBL();

                var userData = new ProfileViewModel();
                
                //Get user profile
                userData = userProfileBL.GetProfileByUserProfileID(userProfileID);

                //Get user notificaitons
                var notifications = notificationBL.GetNotificationsByUser(userProfileID);
                userData.Notifications = notifications;

                //Get user friends
                var friendRequests = friendRequestBL.GetFriendsByUserProfileID(userProfileIDCopy);

                //Get other user friends
                var otherFriendRequests = friendRequestBL.GetFriendsByUserProfileID(userProfileID);

                //Check if friend request sent
                if (friendRequests.Where(w => w.FriendID == userProfileID && w.IsFriendRequestPending == true).ToList().Count > 0)
                {
                    userData.IsFriendRequestSent = true;
                }

                //Check if friend
                if (friendRequests.Where(w => w.FriendID == userProfileID && w.IsFriendRequestPending == false).ToList().Count > 0
                    || otherFriendRequests.Where(w => w.FriendID == userProfileIDCopy && w.IsFriendRequestPending == false).ToList().Count > 0)
                {
                    userData.IsFriend = true;
                }

                //Check if friend request pending
                //if (friendRequestBL.GetFriendsByUserProfileID(userProfileIDCopy, true).Count > 0)
                if (friendRequests.Where(w => w.IsFriendRequestPending == true).ToList().Count > 0)
                {
                    userData.IsFriendRequestPending = true;
                }

                var today = DateTime.Today;
                // Calculate the age.
                var age = today.Year - userData.DOB.Value.Year;
                // Do stuff with it.
                if (userData.DOB.Value > today.AddYears(-age))
                {
                    age--;
                    userData.Age = age.ToString() + " y";
                }

                if (System.Web.HttpContext.Current.Request.QueryString["user"] != null && System.Web.HttpContext.Current.Request.QueryString["user"] != "")
                {
                    if (userProfileIDCopy == Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["user"]))
                    {
                        userData.IsOwnProfile = true;
                    }
                    else
                    {
                        userData.IsOwnProfile = false;
                    }
                }
                else
                {
                    userData.IsOwnProfile = true;
                }
                ViewBag.LayoutModel = userData;
            }
        }
    }
}