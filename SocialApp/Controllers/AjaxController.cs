using SocialApp.BL;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialApp.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        [Authorize(Roles = "User")]
        [HttpPost]
        public JsonResult SaveUserPost(PostViewModel postVM)
        {
            var result = "success";
            try
            {
                new PostBL().SavePost(postVM);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public JsonResult SaveFriendRequest(UserFriendViewModel friendRequestVM)
        {
            var result = "success";
            try
            {
                new FriendRequestBL().SaveFriendRequest(friendRequestVM);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public JsonResult SearchUsers(string Prefix, int orgID)
        {
            var users = new DisplayProfileBL().GetUsersByOrganization(orgID);
            Prefix = Prefix.ToLower();
            //Searching records from list using LINQ query  
            var searchedUsers = users.Where(w => w.FirstName.ToLower().StartsWith(Prefix) || w.LastName.ToLower().StartsWith(Prefix)).Select(s => new
            {
                Route = "/Home/Wall?user=" + s.UserProfileID,
                Name = s.FirstName + " " + s.LastName
            });

            return Json(searchedUsers, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        public JsonResult GetUserFriends(int userProfileID, bool isFriendRequestPending)
        {
            var friendRequests = new FriendRequestBL().GetFriendsByUserProfileID(userProfileID, isFriendRequestPending);

            return Json(friendRequests, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        public JsonResult RemoveFriendRequest(int friendID)
        {
            var result = "success";
            new FriendRequestBL().RemoveFriend(friendID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        public JsonResult AddLike(LikesVM likeVM)
        {
            var result = new LikeBL().SaveLike(likeVM);
            if (result)
            {
                new NotificationBL().SaveNotification(new NotificationViewModel()
                {
                    Active = true,
                    Description = likeVM.NotificationFromFullName + " liked your post.",
                    Link = "",
                    UserProfileID = likeVM.NotificationTo
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        public JsonResult RemoveLike(int likeID)
        {
            var result = "success";
            new LikeBL().RemoveLike(likeID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        public JsonResult SaveComment(CommentsVM commentVM)
        {
            var result = "success";
            new CommentBL().SaveComment(commentVM);
            new NotificationBL().SaveNotification(new NotificationViewModel()
            {
                Active = true,
                Description = commentVM.NotificationFromFullName + " commented on your post.",
                Link = "",
                UserProfileID = commentVM.NotificationTo
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendMessage(UserMessageViewModel messageVM)
        {
            var result = "success";

            new MessageBL().SendMessage(messageVM);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PostComments(int postID)
        {
            var postComments = new CommentBL().GetCommentsByPostID(postID);
            return PartialView(postComments);
        }

    }
}