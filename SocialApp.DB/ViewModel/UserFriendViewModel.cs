using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
    public class UserFriendViewModel
    {
        public int UserFriendID { get; set; }
        public int? FriendID { get; set; }
        public int? UserProfileID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string FriendRequestFullName { get; set; }
        public string FriendRequestProfilePath { get; set; }
        public bool? IsFriendRequestPending { get; set; }
    }
}
