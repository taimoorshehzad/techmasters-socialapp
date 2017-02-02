using SocailApp.Repository;
using SocialApp.DB.Model;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.BL
{
    public class FriendRequestBL
    {
        IUserFriendRepository friendRepository = new UserFriendRepository();

        public void SaveFriendRequest(UserFriendViewModel userfriendVM)
        {
            UserFriend userFriend = new UserFriend();
            userFriend.CreatedOn = DateTime.Now;
            userFriend.FriendID = userfriendVM.FriendID;
            userFriend.UserProfileID = userfriendVM.UserProfileID;
            userFriend.IsRequestPending = userfriendVM.IsFriendRequestPending;
            userFriend.UserFriendID = userfriendVM.UserFriendID;
            friendRepository.Save(userFriend);
        }

        public List<UserFriendViewModel> GetFriendsByUserProfileID(int userProfileID, bool isFriendRequestPending)
        {
            return friendRepository.GetFriendsByUser(userProfileID, isFriendRequestPending).Select(s => new UserFriendViewModel()
            {
                CreatedOn = s.CreatedOn,
                UserFriendID = s.UserFriendID,
                FriendID = s.FriendID,
                UserProfileID = s.UserProfileID,
                FriendRequestFullName = s.UserProfile.FirstName + " " + s.UserProfile.LastName,
                FriendRequestProfilePath = s.UserProfile.ProfilePicPath,
                IsFriendRequestPending = s.IsRequestPending
            }).ToList();
        }
        public List<UserFriendViewModel> GetFriendsByUserProfileID(int userProfileID)
        {
            return friendRepository.GetFriendsByUser(userProfileID).Select(s => new UserFriendViewModel()
            {
                CreatedOn = s.CreatedOn,
                UserFriendID = s.UserFriendID,
                FriendID = s.FriendID,
                UserProfileID = s.UserProfileID,
                FriendRequestFullName = s.UserProfile.FirstName + " " + s.UserProfile.LastName,
                FriendRequestProfilePath = s.UserProfile.ProfilePicPath,
                IsFriendRequestPending = s.IsRequestPending
            }).ToList();
        }

        public void RemoveFriend(int friendRequestID)
        {
            friendRepository.Delete(friendRequestID);
        }
    }
}
